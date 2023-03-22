using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1.Code
{
    public class sachbll
    {
        XmlDocument doc = new XmlDocument();
        XmlElement root;
        string fileName = "..\\..\\book.xml";
        public sachbll()
        {
            doc.Load(fileName);
            root= doc.DocumentElement;
        }
        public void Them(Sach sachThem)
        {
            XmlElement sach = doc.CreateElement("book");

            XmlElement title = doc.CreateElement("title");
            title.InnerText = sachThem.title;
            sach.AppendChild(title);

            XmlElement author = doc.CreateElement("author");
            author.InnerText = sachThem.author;
            sach.AppendChild(author);

            XmlElement year = doc.CreateElement("year");
            year.InnerText = sachThem.year;
            sach.AppendChild(year);

            XmlElement price = doc.CreateElement("price");
            price.InnerText = sachThem.price;
            sach.AppendChild(price);
            
            XmlAttribute category = doc.CreateAttribute("category");
            category.InnerText = sachThem.category;
            sach.SetAttributeNode(category);

            root.AppendChild(sach);
            doc.Save(fileName);
        }
        public void Sua(Sach sachSua)
        {
            XmlNode sachCu = root.SelectSingleNode("book[title = '" + sachSua.title + "']");
            if(sachCu != null)
            {
                XmlNode sachSuaMoi = doc.CreateElement("book");

                XmlElement title = doc.CreateElement("title");
                title.InnerText = sachSua.title;
                sachSuaMoi.AppendChild(title);

                XmlElement author = doc.CreateElement("author");
                author.InnerText = sachSua.author;
                sachSuaMoi.AppendChild(author);

                XmlElement year = doc.CreateElement("year");
                year.InnerText = sachSua.year;
                sachSuaMoi.AppendChild(year);

                XmlElement price = doc.CreateElement("price");
                price.InnerText = sachSua.price;
                sachSuaMoi.AppendChild(price);

                root.ReplaceChild(sachSuaMoi, sachCu);
                doc.Save(fileName);
            }
        }
        public void Xoa(Sach sachXoa)
        {
            XmlNode sachCanXoa = root.SelectSingleNode("book[title = '" + sachXoa.title + "']");
            if(sachCanXoa != null)
            {
                root.RemoveChild(sachCanXoa);

                doc.Save(fileName);
            }
        }
        public void TimKiem(Sach sachTimKiem, DataGridView dataGridView) 
        {
            dataGridView.Rows.Clear();
            XmlNode sachCanTim = root.SelectSingleNode("book[title ='" + sachTimKiem.title + "']");
            if(sachCanTim != null)
            {
                dataGridView.ColumnCount = 5;
                dataGridView.Rows.Add();

                dataGridView.Rows[0].Cells[0].Value = sachCanTim.Attributes["category"].InnerText;

                dataGridView.Rows[0].Cells[1].Value = sachCanTim.SelectSingleNode("title").InnerText;

                dataGridView.Rows[0].Cells[2].Value = sachCanTim.SelectSingleNode("author").InnerText;

                dataGridView.Rows[0].Cells[3].Value = sachCanTim.SelectSingleNode("year").InnerText;

                dataGridView.Rows[0].Cells[4].Value = sachCanTim.SelectSingleNode("price").InnerText;
            }
        }
        
        public void hienThi(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            dataGridView.ColumnCount = 5;

            XmlNodeList ds = root.SelectNodes("book");
            int sd = 0;
            foreach(XmlNode item in ds)
            {
                dataGridView.Rows.Add();
                dataGridView.Rows[sd].Cells[0].Value = item.Attributes["category"].InnerText;
                dataGridView.Rows[sd].Cells[1].Value = item.SelectSingleNode("title").InnerText;
                dataGridView.Rows[sd].Cells[2].Value = item.SelectSingleNode("author").InnerText;
                dataGridView.Rows[sd].Cells[3].Value = item.SelectSingleNode("year").InnerText;
                dataGridView.Rows[sd].Cells[4].Value = item.SelectSingleNode("price").InnerText;
                sd++;
            }
        }
    }
}
