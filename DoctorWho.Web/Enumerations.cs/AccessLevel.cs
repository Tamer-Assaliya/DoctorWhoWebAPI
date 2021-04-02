
namespace DoctorWho.Web.Enumerations
{
    public enum AccessLevel
    {
        //null safe
        Unknown,
        Redacted,
        Partial,
        RequestChange,
        Modify
    }
}
