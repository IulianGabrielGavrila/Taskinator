﻿namespace TaskinatorDAL.Models
{
    public enum User_role
    {
        Creator, Developer, Tester
    }
    public class Board_Employee
    {
        
        public Employee Employee { get; set; }

        //Board_ID
        public Board Board { get; set; }

        //Rol user board(enum: creator,developer,tester)
        
        public User_role? User_role { get; set; }
       


        
    

    
    
}
}
