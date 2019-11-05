using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafe_POS
{
    class Kasir
    {
        private int id;
        private string nama_pengguna;

        public Kasir(int id, string nama_pengguna)
        {
            this.id = id;
            this.nama_pengguna = nama_pengguna;
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set => this.id = value;
        }

        public string NamaPengguna
        {
            get
            {
                return this.nama_pengguna;
            }

            set => this.nama_pengguna = value;
        }
    }
}
