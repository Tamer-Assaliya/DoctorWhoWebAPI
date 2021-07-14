using System.Collections.Generic;

namespace DoctorWho.Db.Contracts
{
    public interface IDoctorRepository
    {
        Doctor GetDoctor(int id);

        void CreatDoctor(int id, Doctor doctorToCreate);

        void UpdateDoctor(int id, Doctor doctorToUpdate);

        void DeleteDoctor(Doctor doctor);

        List<Doctor> GetAllDoctors();
    }
}