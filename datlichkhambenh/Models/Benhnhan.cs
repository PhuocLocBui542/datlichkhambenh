using datlichkhambenh.Models;
using System;
using System.Collections.Generic;

namespace datlichkhambenh.Models;

public partial class Benhnhan
{
    public int Mabn { get; set; }

    public string? Tenbn { get; set; }

    public DateTime? Ngaysinh { get; set; }

    public string? Gioitinh { get; set; }

    public string? Account { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Lichkham> Lichkhams { get; set; } = new List<Lichkham>();
}
