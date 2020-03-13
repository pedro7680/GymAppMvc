using GymApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using GymApp.DataAccess.Repository.IRepository;
using GymApp.DataAccess.Data;
using System.Linq;

namespace GymApp.DataAccess.Repository
{
    public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
    {
        private readonly ApplicationDbContext _db;

        public ExerciseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Exercise exercise)
        {
            var objFromDb = _db.Exercises.FirstOrDefault(s => s.Id == exercise.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = exercise.Name;
               
            }
        }
    }
}
