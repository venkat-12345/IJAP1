﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJAPLibrary
{
    public interface IJobRepoAsync
    {
        Task<List<Job>> GetAllJobsAsync();
        Task<Job> GetJobByIdAsync(string jobid);

    }
}
