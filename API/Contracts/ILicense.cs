using Hunter.API.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hunter.API.Contracts
{
    public enum LicenseTypes
    {
        Base_Math = 0x01,
        Base_TravelingSalesman = 0x02,
        Invest_Futures_Wheat = 0x04,
        Invest_Futures_Soy = 0x08,
        Invest_Stocks = 0x10,
        Invest_Bonds = 0x20,
        Invest_Bitcoin = 0x40,
        MaterialSci = 0x80,
        Bio_Cancer_Breast = 0x0100
    }

    public interface ILicense
    {
        public string Name { get; set; }
        public List<LicenseTypes> LicenseTypes { get; set; }
        public int LicenseMask { get; set; }

        [ForeignKey(nameof(Company))]
        public Company Company { get; set; }
    }
}
