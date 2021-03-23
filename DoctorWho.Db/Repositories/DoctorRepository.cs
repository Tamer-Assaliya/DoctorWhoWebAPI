using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db
{
    public class DoctorRepository
    {
        private static DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();

        public Doctor GetDoctor(int id)
        {
            var doctor = _context.Find<Doctor>(id);
            return doctor;
        }
        public void CreatDoctor(int id, Doctor doctorToCreate)
        {
            doctorToCreate.DoctorId = id;
            var doctor = doctorToCreate;
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public void UpdateDoctor(int id, Doctor doctorToUpdate)
        {
            var doctor = _context.Find<Doctor>(id);
            doctor = doctorToUpdate;
            _context.SaveChanges();
        }

        public void DeleteDoctor(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }

        public List<Doctor> GetAllDoctors()
        {
            var doctors = _context.Doctors.Select(d => d).ToList();
            return doctors;
        }
    }
}
