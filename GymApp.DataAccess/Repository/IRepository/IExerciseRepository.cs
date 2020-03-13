using GymApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.DataAccess.Repository.IRepository
{
    public interface IExerciseRepository : IRepository<Exercise>
    {
        void Update(Exercise exercise);
    }
}
