using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_122
{
    class Node
    {
        public int id;
        public string nama;
        public string jenis;
        public int harga;

        public Node next;
    }

    class singgle_linked_list
    {
        Node START;

        public singgle_linked_list()
        {
            START = null;
        }

        public void addNode()
        {
            int idb, hargab;
            string namab, jenisb;
            Console.WriteLine("\nMasukkan ID barang: ");
            idb = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nMasukkan Nama barang: ");
            namab = Console.ReadLine();
            Console.WriteLine("\nMasukkan Jenis barang: ");
            jenisb = Console.ReadLine();
            Console.WriteLine("\nMasukkan harga barang: ");
            hargab = Convert.ToInt32(Console.ReadLine());
            Node newNode = new Node();
            newNode.id = idb;
            newNode.nama = namab;
            newNode.jenis = jenisb;
            newNode.harga = hargab;

            if (START == null || idb <= START.id)
            {
                if ((START != null) && (idb <= START.id))
                {
                    Console.WriteLine("\nDuplicate number of id not allowed");
                    return;
                }
                newNode.next = START;
                START = newNode;
                return;
            }
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (idb >= current.id))
            {
                if (idb == current.id)
                {
                    Console.WriteLine("\nDuplicate roll number not allowed\n");
                    return;
                }
                previous = current;
                current = current.next;
            }

            newNode.next = current;
            previous.next = newNode;
        }

        public void traverse()
        {
            if (listEmpty())
            {
                Console.WriteLine("\nList is Empty");

            }
            else
            {
                Console.WriteLine("\nThe records in the list are : ");
                Node currentNode;
                for (currentNode = START; currentNode != null;
                    currentNode = currentNode.next)
                {
                    Console.Write(currentNode.id + " " + currentNode.nama + " " + currentNode.jenis + " " + currentNode.harga + "\n");
                }
                Console.WriteLine();
            }
        }

        public void terjenisbar(string jenisb)
        {
            if (listEmpty())
            {
                Console.WriteLine("\nList is Empty");

            }
            else
            {
                Console.WriteLine("\nThe records in the list are : ");
                Node currentNode;
                for (currentNode = START; currentNode != null;
                    currentNode = currentNode.next)
                {
                    if (jenisb == currentNode.jenis)
                    {
                        Console.Write(currentNode.id + " " + currentNode.nama + " "+ currentNode.jenis + " " + currentNode.harga + "\n");
                    }
                    
                }
                Console.WriteLine();
            }
        }

        public bool Search(int idb, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current != null) && (idb != current.id))
            {
                previous = current;
                current = current.next;

            }
            if (current == null)
            {
                return (false);
            }
            else
            {
                return (true);
            }

        }

        public bool delNode(int idb)
        {
            Node previous, current;
            previous = current = null;
            
            if (Search(idb, ref previous, ref current) == false)
            {
                return false;
            }
            previous.next = current.next;
            if (current == START)
            {
                START = START.next;
            }
            return true;
        }

        public bool listEmpty()
        {
            if (START == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            singgle_linked_list obj = new singgle_linked_list();

            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Menambahkan barang baru");
                    Console.WriteLine("2. Menghapus barang dari daftar list");
                    Console.WriteLine("3. view all the records in the list");
                    Console.WriteLine("4. Search for a record in the list");
                    Console.WriteLine("5. mencari menurut jenid barang");
                    Console.WriteLine("6. EXIT");
                    Console.Write("\nEnter your choice (1-6) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.Write("\nEnter the roll number of the student whose record is to be delete :");
                                int idb = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(idb) == false)
                                {
                                    Console.WriteLine("\nRecord not found.");
                                }
                                else
                                {
                                    Console.WriteLine("Record with roll number " + idb + " Deleted");
                                }
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nEnter the roll number of the student whose record is to be search :");
                                int idb = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(idb, ref previous, ref current) == false)
                                {
                                    Console.WriteLine("\nRecord not found.");
                                }
                                else
                                {
                                    Console.WriteLine("\nRecord found!!!");
                                    Console.WriteLine("\nId Barang: " + current.id);
                                    Console.WriteLine("\nNama Barang: " + current.nama);
                                    Console.WriteLine("\nJenis Barang: " + current.jenis);
                                    Console.WriteLine("\nHarga Barang: " + current.harga);
                                }
                            }
                            break;
                        case '5':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.WriteLine("\nMasukkan jenis barang yang inginn dicari: ");
                                string jenisb = Console.ReadLine();
                                obj.terjenisbar(jenisb);
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid Option");
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nCheck for the value entered");
                }
            }
        }
    }

    /*Jawaban 
     * 2. menggunakan singgle linked list karena pembacaan data hanya adri depan ke belakan dan data langsung dimasukkan setelah diinput kedalam list.
     *    dengan linked list id, nama, jenis, dan harga bisa ditempatkan dalam satu wadah yaitu Node.
     * 3. Perbadaannya terdapat pada sistem penyimpanan, array sudah ditentukan diawal berapa data yang akan disimpan dengan pengurutan berdasarkan index 
     *    sebagai posisi data sedangkan linked list tidak ditentukan serta pengurutan berdasarkan node selanjutnya dari setiap data.
     * 4. REAR dan FFRONT
     * 5. a. sibling of 16 is 53, sibling of 46 is 55, sibling of 41 is 74, sibling of 63 is 70, sibling of 62 is 64, dan yang tidak punya sibling 25, 42, 60, 65
     *    b. inorder hasilnya: 16 25 41 42 46 53 55 60 62 63 64 65 70 74
     */
}
