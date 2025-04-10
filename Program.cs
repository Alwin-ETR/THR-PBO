using System;

namespace GajiKaryawan
{
    class Karyawan
    {
        private string nama;
        private string id;
        private double gajiPokok;

        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public double GajiPokok
        {
            get { return gajiPokok; }
            set { gajiPokok = value; }
        }

        public Karyawan(string nama, string id, double gajiPokok)
        {
            this.nama = nama;
            this.id = id;
            this.gajiPokok = gajiPokok;
        }

        public virtual double HitungGaji()
        {
            return gajiPokok;
        }
    }

    class KaryawanTetap : Karyawan
    {
        public KaryawanTetap(string nama, string id, double gajiPokok)
            : base(nama, id, gajiPokok) { }

        public override double HitungGaji()
        {
            return GajiPokok + 500000;
        }
    }

    class KaryawanKontrak : Karyawan
    {
        public KaryawanKontrak(string nama, string id, double gajiPokok)
            : base(nama, id, gajiPokok) { }

        public override double HitungGaji()
        {
            return GajiPokok - 200000;
        }
    }

    class KaryawanMagang : Karyawan
    {
        public KaryawanMagang(string nama, string id, double gajiPokok)
            : base(nama, id, gajiPokok) { }

        public override double HitungGaji()
        {
            return GajiPokok;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Masukkan jenis karyawan (tetap/kontrak/magang): ");
            string jenis = Console.ReadLine().ToLower();

            Console.Write("Masukkan nama: ");
            string nama = Console.ReadLine();

            Console.Write("Masukkan ID: ");
            string id = Console.ReadLine();

            Console.Write("Masukkan gaji pokok: ");
            double gajiPokok;

            while (!double.TryParse(Console.ReadLine(), out gajiPokok))
            {
                Console.Write("Input tidak valid. Masukkan angka untuk gaji pokok: ");
            }

            Karyawan karyawan;

            if (jenis == "tetap")
            {
                karyawan = new KaryawanTetap(nama, id, gajiPokok);
            }
            else if (jenis == "kontrak")
            {
                karyawan = new KaryawanKontrak(nama, id, gajiPokok);
            }
            else if (jenis == "magang")
            {
                karyawan = new KaryawanMagang(nama, id, gajiPokok);
            }
            else
            {
                Console.WriteLine("Jenis karyawan tidak valid.");
                return;
            }

            Console.WriteLine("\n--- Data Karyawan ---");
            Console.WriteLine($"Nama        : {karyawan.Nama}");
            Console.WriteLine($"ID          : {karyawan.ID}");
            Console.WriteLine($"Gaji Akhir  : {karyawan.HitungGaji():N0}");
        }
    }
}
