import React from 'react'
import './addagent.css'
import Sidebar from '../sidebar/Sidebar'
import Navbar from '../navbar/Navbar'
import { Link } from 'react-router-dom'

function addagent() {
  return (
    <div className="sidee">
            <Sidebar />
            <div className="navv">
                <Navbar />
    <div>
        <div className='top-container'>
        
        <div className='text-team'>Team</div> 
           
       </div>
       <div className='agent-details'>
       <Link to="/teams" className="create">
          Create
          </Link>
       <div className='textfield-1'>Name</div>
       <input className='namefield' type="Text"></input>
       <div> 
        <div className='agent'> Agent</div>
        <select className='agentselect'>
       <option>Choose Agent</option>
       </select></div>
       
       <div className='textfield-2'>Username</div>
       <input className='emailfield' type="Text"></input>
       <div className='textfield-3'>password</div>
       <input className='passfield' type="password"></input>
       <div>
        
     </div>
       </div>
    </div>
    </div>
    </div>
  )
}

export default addagent
