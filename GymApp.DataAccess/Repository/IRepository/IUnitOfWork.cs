﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IExerciseRepository Exercise { get; }
        ISP_Call SP_Call { get; }

        void Save();
    }
}
