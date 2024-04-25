    using System;
    using System.Collections.Generic;

    namespace DoAnLTWeb.Models;

    public partial class Staff
    {
        public int Idstaff { get; set; }

        public string StaffName { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string StaffAddress { get; set; } = null!;

        public string PhoneStaff { get; set; } = null!;

        public string CitizenIdentificationCode { get; set; } = null!;

        public int IdstaffType { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public int Sex { get; set; }

        public int? IdImages { get; set; }

        public virtual ICollection<DeliveryNote> DeliveryNotes { get; set; } = new List<DeliveryNote>();

        public virtual Image? IdImagesNavigation { get; set; }

        public virtual StaffType IdstaffTypeNavigation { get; set; } = null!;

        public virtual ICollection<ImportedProduct> ImportedProducts { get; set; } = new List<ImportedProduct>();

        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

        public virtual ICollection<SkillDetail> SkillDetails { get; set; } = new List<SkillDetail>();

        public virtual User UsernameNavigation { get; set; } = null!;
    }
