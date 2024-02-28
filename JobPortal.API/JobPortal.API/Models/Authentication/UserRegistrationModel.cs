﻿using Microsoft.AspNetCore.Http.HttpResults;

namespace JobPortal.API.Models.Authentication
{
    public class UserRegistrationModel
    {
    
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public int UserType { get; set; }

        public DateTime RegistrationDate {  get; set; }

        public bool IsActive { get; set; }


        
    }
}

/*CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY,
    UserName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    UserPassword VARCHAR(255) NOT NULL,
    UserType INT NOT NULL,
    RegistrationDate DATETIME NOT NULL,
    IsActive BIT NOT NULL
);*/
