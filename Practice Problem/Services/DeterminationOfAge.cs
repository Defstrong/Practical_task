
namespace Practice_Problem.Services
{
    public class DeterminationOfAge
    {
        public static int AgeDetermination(DateTime DateOfBirth)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.AddYears(age) > today)
            {
                age--;
            }
            return age;
        }
    }
}
