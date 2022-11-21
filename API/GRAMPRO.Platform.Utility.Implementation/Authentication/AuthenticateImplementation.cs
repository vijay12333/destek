// using System;
// using System.Collections.Generic;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.Extensions.Configuration;
// using Microsoft.IdentityModel.Tokens;
// using GRAMPRO.Platform.Utility.Model.General;
// using GRAMPRO.Platform.Utility.Model.Authentication;
// using GRAMPRO.Platform.Utility.Model;
// using System.Data;
// using GRAMPRO.Platform.Utility.Repository;
// using Microsoft.Extensions.Configuration;
// using System.Linq;
// using Service.Repository.Authenticate;
// using Service.DAL.ConnectionADO;
// using Microsoft.EntityFrameworkCore;

// namespace GRAMPRO.Platform.Utility.Implementation.Authentication
// {

//     public class AuthenticateImplementation : IAuthenticateImplementation
//     {
//         private Response _response;
//         private IAuthenticateRepository _authenticateRepository;

//         private ApplicationContext _context;
//         private IConfigurationRoot _config;
//         private IDbConnection con;


//         private readonly UserManager<ApplicationUser> userManager;
//         private readonly RoleManager<IdentityRole> roleManager;
//         private readonly IConfiguration _configuration;

//         public AuthenticateImplementation(IAuthenticateRepository authenticateRepository, ApplicationContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IConfigurationRoot config)
//         {
//             _context = context ?? throw new System.ArgumentNullException(nameof(context));

//             this.userManager = userManager;
//             this.roleManager = roleManager;
//             _configuration = configuration;
//             _response = new Response();
//             _config = config;
//             _authenticateRepository = authenticateRepository;

//         }

//         public async Task<Response> Login(LoginModel model)
//         {
//             try
//             {
//                 var user = await userManager.FindByNameAsync(model.Username);
//                 if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
//                 {
//                     var userRoles = await userManager.GetRolesAsync(user);

//                     var authClaims = new List<Claim>
//                 {
//                     new Claim(ClaimTypes.Name, user.UserName),
//                     new Claim("UserId", user.Id),
//                     //new Claim("CompanyId", Convert.ToString(user.CompanyId)),
//                     //new Claim("UserRoleId",Convert.ToString(user.UserRoleId)),
//                     new Claim("EntityId",Convert.ToString(user.EntityId)),

//                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//                 };

//                     foreach (var userRole in userRoles)
//                     {
//                         authClaims.Add(new Claim(ClaimTypes.Role, userRole));
//                     }

//                     var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

//                     var token = new JwtSecurityToken(
//                         issuer: _configuration["JWT:ValidIssuer"],
//                         audience: _configuration["JWT:ValidAudience"],
//                         expires: DateTime.Now.AddDays(3),
//                         claims: authClaims,
//                         signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
//                         );
//                     _response.Success = true;
//                     _response.Data = new RegisterModel
//                     {
//                         Username = model.Username,
//                         DisplayName = user.DisplayName,
//                         PhoneNumber = user.PhoneNumber,

//                         Token = new JwtSecurityTokenHandler().WriteToken(token)
//                     };
//                     return _response;
//                 }
//                 _response.Success = false;
//                 _response.Data = new AuthResponse { Status = "Failed", Message = "Internal server error, please try again.!" };
//                 return _response;
//             }
//             catch (System.Exception)
//             {
//                 _response.Success = false;
//                 return _response;
//             }

//         }

//         public async Task<Response> Register(RegisterModel model)
//         {
//             try
//             {
//                 var userExists = await userManager.FindByNameAsync(model.Username);
//                 if (userExists != null)
//                 {
//                     _response.Success = false;
//                     _response.Data = new AuthResponse { Status = "Error", Message = "User already exists!" };
//                     return _response;
//                 }

//                 ApplicationUser user = new ApplicationUser()
//                 {
//                     Email = model.Email,
//                     SecurityStamp = Guid.NewGuid().ToString(),
//                     UserName = model.Username,
//                     PhoneNumber = model.PhoneNumber,
//                     // CompanyId = model.CompanyId,
//                     EntityId = model.EntityId,
//                     //UserRoleId = model.UserRoleId,

//                     //Status = 1,
//                     DisplayName = model.DisplayName
//                 };
//                 var result = await userManager.CreateAsync(user, model.Password);
//                 if (!result.Succeeded)
//                 {
//                     _response.Success = false;
//                     _response.Data = new AuthResponse { Status = "Error", Message = "User creation failed! Please check user details and try again." };
//                     return _response;
//                 }

//                 if (!await roleManager.RoleExistsAsync(UserRoles.User))
//                     await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

//                 if (await roleManager.RoleExistsAsync(UserRoles.User))
//                 {
//                     await userManager.AddToRoleAsync(user, UserRoles.User);
//                 }

//                 _response.Success = true;
//                 _response.Data = new AuthResponse { Status = "Success", Message = "User created successfully!" };
//                 return _response;
//             }
//             catch (System.Exception)
//             {
//                 _response.Success = false;
//                 return _response;
//             }
//         }

//         public async Task<Response> RegisterAdmin(RegisterModel model)
//         {
//             try
//             {
//                 var userExists = await userManager.FindByNameAsync(model.Username);
//                 if (userExists != null)
//                 {
//                     _response.Success = false;
//                     _response.Data = new AuthResponse { Status = "Error", Message = "User already exists!" };
//                     return _response;
//                 }

//                 ApplicationUser user = new ApplicationUser()
//                 {
//                     Email = model.Email,
//                     SecurityStamp = Guid.NewGuid().ToString(),
//                     UserName = model.Username,
//                     PhoneNumber = model.PhoneNumber,
//                     // CompanyId = model.CompanyId,
//                     EntityId = model.EntityId,
//                     //UserRoleId = model.UserRoleId,
//                     //Status = 1,
//                     DisplayName = model.DisplayName
//                 };
//                 var result = await userManager.CreateAsync(user, model.Password);
//                 if (!result.Succeeded)
//                 {
//                     _response.Success = false;
//                     _response.Data = new AuthResponse { Status = "Error", Message = "User creation failed! Please check user details and try again." };
//                     return _response;
//                 }

//                 if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
//                     await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
//                 if (!await roleManager.RoleExistsAsync(UserRoles.User))
//                     await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

//                 if (await roleManager.RoleExistsAsync(UserRoles.Admin))
//                 {
//                     await userManager.AddToRoleAsync(user, UserRoles.Admin);
//                 }

//                 _response.Success = true;
//                 _response.Data = new AuthResponse { Status = "Success", Message = "User created successfully!" };
//                 return _response;
//             }
//             catch (System.Exception)
//             {
//                 _response.Success = false;
//                 return _response;
//             }

//         }

//         public Response GetEntityType(string filter)
//         {
//             try
//             {
//                 if (string.IsNullOrEmpty(filter))
//                 {
//                     _response.Data = this._context.EntityDetails.Where(x => x.Status == 1).ToList();
//                 }
//                 else
//                 {
//                     _response.Data = this._context.EntityDetails.Where(x => x.Status == 1 && x.EntityName.Contains(filter)).ToList();
//                 }

//                 _response.Success = true;
//                 return _response;
//             }
//             catch (System.Exception)
//             {
//                 _response.Success = false;
//                 return _response;
//             }
//         }




//         public Response userRole(string filter)
//         {
//             try
//             {
//                 if (string.IsNullOrEmpty(filter))
//                 {
//                     _response.Data = this._context.UserRole.ToList();
//                 }
//                 else
//                 {
//                     _response.Data = this._context.UserRole.Where(x => x.UserType.Contains(filter)).ToList();
//                 }

//                 _response.Success = true;
//                 return _response;
//             }
//             catch (System.Exception)
//             {
//                 _response.Success = false;
//                 return _response;
//             }
//         }


//        /* public Response getRegister()
//         {
//             try
//             {
//                 using (con = DataContextFactory.GetDataContext(_config))
//                 {
//                     using (IDbTransaction trn = con.BeginTransaction())
//                     {
//                         _response.Success = true;
//                         _authenticateRepository.DbConnection = con;
//                         _authenticateRepository.DbTransaction = trn;
//                         _response.Data = _authenticateRepository.getRegister();
//                         trn.Commit();
//                         return _response;
//                     }
//                 }
//             }
//             catch (System.Exception)
//             {
//                 _response.Success = false;
//                 return _response;
//             }
//         }

//         public Response  getRegisterForEdit(string Id)
//         {
//             try
//             {
//                 using (con = DataContextFactory.GetDataContext(_config))
//                 {
//                     using (IDbTransaction trn = con.BeginTransaction())
//                     {
//                         _response.Success = true;
//                         _authenticateRepository.DbConnection = con;
//                         _authenticateRepository.DbTransaction = trn;
//                         _response.Data = _authenticateRepository.getRegisterForEdit(Id);
//                         trn.Commit();
//                         return _response;
//                     }
//                 }
//             }
//             catch (System.Exception)
//             {
//                 _response.Success = false;
//                 return _response;
//             }
//         }

//         public Response  deleteUser(RegisterModel model)
//         {
//             try
//             {
//                 if (model.Id != null)
//                 {
//                    // var userExists = await userManager.FindByNameAsync(model.Username);

//                      var existingUser = this._context.RegisterModel.Find(model.Id);
//                     if (existingUser != null)
//                     {
//                         //existingUser.Status = -1;
//                         //existingEmployee.ModifiedBy = 2;
//                         //existingEmployee.ModifiedDate = System.DateTime.UtcNow;
//                         this._context.Entry(existingUser).State = EntityState.Modified;
//                         this._context.SaveChanges();
//                     }
//                 }

//                 _response.Success = true;
//                 return _response;
//             }
//             catch (System.Exception ex)
//             {
//                 _response.Success = false;
//                 return _response;
//             }
//         }*/

//     }
// }