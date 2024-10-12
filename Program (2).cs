using System;
using System.Collections.Generic;
enum LoaiPhuongTien { xedap, xehoi };
public abstract class Phuongtien
{
    public string Tenpt { get; set; }
    public string Loainhienlieu { get; set; }

    public void Nhap()
    {
        Console.Write("Nhap ten phuong tien: ");
        Tenpt = Console.ReadLine();
        Console.Write("Nhap loai nhien lieu: ");
        Loainhienlieu = Console.ReadLine();
    }

    public virtual void Hienthi()
    {
        Console.WriteLine("Ten phuong tien: " + Tenpt);
        Console.WriteLine("Loai nhien lieu: " + Loainhienlieu);
    }

    public abstract void Dichuyen();
}

public interface IThongTinThem
{
    int TocDoToiDa();
    float MucTieuThuNhienLieu();
}

public class Xehoi : Phuongtien, IThongTinThem
{
    public override void Dichuyen()
    {
        Console.WriteLine($"{Tenpt} di chuyen bang dong co.");
    }

    public int TocDoToiDa()
    {
        return 200;
    }

    public float MucTieuThuNhienLieu()
    {
        return 8.5f; // Lít/100 km
    }

    public override void Hienthi()
    {
        base.Hienthi();
        Console.WriteLine("Toc do toi da: " + TocDoToiDa() + " km/h");
        Console.WriteLine("Muc tieu thu nhien lieu: " + MucTieuThuNhienLieu() + " lít/100 km");
    }
}

public class Xedap : Phuongtien
{
    public override void Dichuyen()
    {
        Console.WriteLine($"{Tenpt} di chuyen bang suc nguoi.");
    }

    public int TocDoToiDa()
    {
        return 25; // km/h
    }

    public override void Hienthi()
    {
        base.Hienthi();
        Console.WriteLine("Toc do toi da: " + TocDoToiDa() + " km/h");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Phuongtien> danhsachpt = new List<Phuongtien>();

        Console.Write("Nhap so luong phuong tien: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Chon loai phuong tien thu " + (i + 1) + ": (1) Xe hoi, (2) Xe dap");
            int loai = int.Parse(Console.ReadLine());

            Phuongtien pt = null;
            // Lựa chọn loại phương tiện
            switch (loai)
            {
                case 1:
                    pt = new Xehoi();
                    break;
                case 2:
                    pt = new Xedap();
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                    i--;
                    continue;
            }
            pt.Nhap();
            danhsachpt.Add(pt);
        }

        Console.WriteLine("Danh sach phuong tien:");
        foreach (var phuongTien in danhsachpt)
        {
            phuongTien.Hienthi();
            phuongTien.Dichuyen();
            Console.WriteLine();
        }
    }
}
