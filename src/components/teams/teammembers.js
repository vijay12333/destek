import React from 'react'
import { Link } from 'react-router-dom'
import './teammembers.css'
const teammembers = () => {
  return (
    <div>
      <div className='top-container'>
        <Link to="/teams" className='text-team'><div >Team</div> </Link>
        
           <div className='text-team-me'>Team Members</div>
       </div>
       <div className='memberscontainer'>
        <input className='email'type='Text' placeholder='Email'></input>
        <input className='phnumber'type='Text' placeholder='Phone Number'></input>
        <select className='assigndept'>
       <option>Assigned Department</option>
       </select>
       <div>
        <button className='create' >create</button>
     </div>
       </div>
    </div>
  )
}

export default teammembers
