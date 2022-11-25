import React from 'react'
import './Team.css'
import { Link } from 'react-router-dom'
import icon from'../img/sort.png'
import filter from '../img/filter.png'
import kebamenu from'../img/kebamenu.png'
import Sidebar from '../sidebar/Sidebar'
import Navbar from '../navbar/Navbar'

function Team() {
  return (
   <div className="sidee">
            <Sidebar />
            <div className="navv">
                <Navbar />
    <div>
    
     <div className='top-container'>
        
      <div className='text-team'>Team</div> 
      <Link to="/teams/teammembers" className='text-team-me'>
         <div >Team Members</div>
         </Link>
     </div>
     <div>
     <Link to="/teams/addagent" className="link">
          Create Teams
        </Link>
     </div>
                <div className='team-details-container'>
           <div className='text-details'>Team Details</div>
           <img className='sorticon' src={icon} alt=''></img>
           <div className='sort'>Sort</div>
           <div className='filter'>Filter</div>
           <img className='filter-icon'src={filter} alt=''></img>
           <div className='teamnames'>Team Names</div>
        
           </div>
           <div className='container-3'>
           <div className='team1'>Team 1</div>
           <div className='fourmembers'>4 Members</div>
           <div>
        <button className='viewbtn' >VIEW MEMBERS</button>
        <img className='kebabmenu' src={kebamenu}alt=''></img>
     </div>
         
           </div>
           <div className='container-4'>
           <div className='team2'>Team 2</div>
           <div className='fivemembers'>5 Members</div>
           <div>
        <button className='viewbtn' >VIEW MEMBERS</button>
        <img className='kebabmenu' src={kebamenu}alt=''></img>
     </div>
         
           </div>
            <div className='container-5'>
            <div className='team3'>Team 3</div>
           <div className='fivemembers'>4 Members</div>
           <div>
        <button className='viewbtn' >VIEW MEMBERS</button>
        <img className='kebabmenu' src={kebamenu}alt=''></img>
     </div>  
         
           </div> 
           
          
   </div>
    </div>       
    </div>
  )
}

export default Team
