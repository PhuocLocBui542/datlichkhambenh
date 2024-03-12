using System;
using System.Collections.Generic;

namespace datlichkhambenh.Models;

public partial class Lichkham
{
    public int Id { get; set; }

    public int Mabs { get; set; }

    public int Mabn { get; set; }

    public DateTime Ngaykham { get; set; }

    public string? Noidung { get; set; } = null!;

    public virtual Benhnhan MabnNavigation { get; set; } = null!;

    public virtual Bacsi MabsNavigation { get; set; } = null!;
}
