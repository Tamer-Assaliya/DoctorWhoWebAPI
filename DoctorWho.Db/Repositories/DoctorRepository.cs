using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db
{
    public class DoctorRepository
    {
        private static DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();

        public void CreatDoctor(string name, int number, DateTime birthDate, DateTime firstEpisodeDate, DateTime lastEpisodeDate)
        {
            var doctor = new Doctor() { DoctorName = name, DoctorNumber = number, BirthDate = birthDate, FirstEpisodeDate = firstEpisodeDate, LastEpisodeDate = lastEpisodeDate };
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public void UpdateDoctor(int id, string name, int number, DateTime birthDate, DateTime firstEpisodeDate, DateTime lastEpisodeDate)
        {
            var doctor = _context.Find<Doctor>(id);
            doctor.DoctorName = name;
            doctor.DoctorNumber = number;
            doctor.BirthDate = birthDate;
            doctor.FirstEpisodeDate = firstEpisodeDate;
            doctor.LastEpisodeDate = lastEpisodeDate;
            _context.SaveChanges();
        }

        public void DeleteDoctor(int id)
        {
            var doctor = _context.Find<Doctor>(id);
            _context.Remove<Doctor>(doctor);
            _context.SaveChanges();
        }

        public List<Doctor> GetAllDoctors()
        {
            var doctors = _context.Doctors.Select(d => d).ToList();
            return doctors;
        }
    }
}
