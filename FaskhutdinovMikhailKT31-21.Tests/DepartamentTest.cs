using FaskhutdinovMikhailKT_31_21.Models;

namespace FaskhutdinovMikhailKT31_21.Tests
{
    public class DepartamentTest
    {
        [Fact]
        public void IsValidCreateDate_ChuvSU_true()
        {
            var ChuvSU = new Department
            {
                Name = "ChuvSU",
                CreateDate = new DateTime(1967, 08, 17)
            };

            var result = ChuvSU.IsValidCreateDate();

            Assert.True(result);
        }
    }
}