using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace task6._1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }

    abstract class ReaderDecorator: Stream
    {
        protected string path;
        protected Stream stream;

        public ReaderDecorator(string path)
        {
            this.path = path;
        }
    }
    class WithPasswordReader : ReaderDecorator
    {
        StreamReader s;
        string pass;
        public WithPasswordReader(string path, string pass) : base(path)
        {
            this.pass = pass;
            this.path = path;
        }
        public string ReadAll()
        {
            try
            {
                String passw = Microsoft.VisualBasic.Interaction.InputBox("Введите пароль", "Ввод пароля", "", 100, 100);
                if (!passw.Equals(pass))
                {
                    MessageBox.Show("Неверный пароль!");
                    throw new Exception("Неверный пароль!");
                }
                using (StreamReader s = new StreamReader(path))
                {
                    StringBuilder sb = new StringBuilder();
                    string line;
                    while ((line = s.ReadLine()) != null)
                    {
                        sb.Append(line + '\n');
                    }
                    return sb.ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();

        }
        public override bool CanRead
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool CanSeek
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool CanWrite
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override long Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override long Position
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void Flush()
        {
            throw new NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
    class WithProgressReader:ReaderDecorator
    {
        StreamReader s;
        public WithProgressReader(string path, ProgressBar pg) : base(path)
        {
            pg.Visible = true;
            this.path = path;
        }
        public string ReadAll()
        {
            try
            {
                using (StreamReader s = new StreamReader(path))
                {
                    StringBuilder sb = new StringBuilder();
                    string line;
                    while ((line = s.ReadLine()) != null)
                    {
                        sb.Append(line+'\n');
                    }
                    return sb.ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
        public override bool CanRead
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool CanSeek
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool CanWrite
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override long Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override long Position
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void Flush()
        {
            throw new NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}
