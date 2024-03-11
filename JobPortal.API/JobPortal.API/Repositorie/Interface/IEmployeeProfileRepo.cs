﻿using JobPortal.API.Models;

namespace JobPortal.API.Repositorie.Interface
{
    public interface IEmployeeProfileRepo
    {
        public Task<int> SetProfileInfo(EmployeeProfileModel profile);
    }
}