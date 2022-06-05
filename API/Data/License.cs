using Hunter.API.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hunter.API.Data
{
    public class License : ILicense
    {
        public int LicenseMask { get; set; }

        public License(string name, List<LicenseTypes> licenseTypes, Company company)
        {
            Name = name;
            LicenseTypes = licenseTypes;
            Company = company;
            LicenseMask = 0;
        }

        public string Name { get; set; }
        public List<LicenseTypes> LicenseTypes { get; set; }

        public int CalcLicenseMask(List<LicenseTypes> licenseList)
        {
            int mask = 0;
            for(int i = 0; i < licenseList.Count; i++)
            {
                LicenseTypes licenseType = licenseList[i];
                mask |= (int)licenseType;
            }
            this.LicenseMask = mask;
            return mask;
        }

        public int AddLicenses(List<LicenseTypes> newLicenses)
        {
            for (int i = 0; i < newLicenses.Count; i++)
            {
                LicenseTypes licenseType = newLicenses[i];
                this.LicenseMask |= (int)licenseType;
            }
            return this.LicenseMask;
        }

        public int RemoveLicenses(List<LicenseTypes> delLicenses)
        {
            int mask = ~LicenseMask;
            for (int i = 0; i < delLicenses.Count; i++)
            {
                LicenseTypes licenseType = delLicenses[i];
                this.LicenseMask |= (int)licenseType;
            }
            LicenseMask = ~mask;
            return LicenseMask;
        }

        public bool HasLicense(LicenseTypes licenseType)
        {
            return (LicenseMask & (int)licenseType) != 0;
        }

        [ForeignKey(nameof(Company))]
        public Company Company { get; set; }
    }
}
