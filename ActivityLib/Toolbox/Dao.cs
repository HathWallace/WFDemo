using System.IO;
using System.Xml;

namespace ActivityLib.Toolbox
{
    public class Dao
    {
        public static string Path => "Dao.xml";

        public void Create(int id)
        {
            if (!File.Exists(Path)) CreateXml();

            var xd = new XmlDocument();
            xd.Load(Path);

            var node = xd.CreateElement("workflow");
            node.SetAttribute("Id", id.ToString());
            node.SetAttribute("IsCounterSign", false.ToString());
            xd.SelectSingleNode("Workflow").AppendChild(node);

            xd.Save(Path);
        }

        private void CreateXml()
        {
            var xd = new XmlDocument();
            xd.AppendChild(xd.CreateXmlDeclaration("1.0", "utf-8", null));
            xd.AppendChild(xd.CreateElement("Workflow"));
            xd.Save(Path);
        }

        public void Update(int id, bool isCounterSign)
        {
            if (!File.Exists(Path)) return;

            var xd = new XmlDocument();
            xd.Load(Path);

            var node = xd.SelectSingleNode($"Workflow/workflow[@Id={id}]");
            if (node == null) return;
            node.Attributes["IsCounterSign"].Value = isCounterSign.ToString();

            xd.Save(Path);
        }

        public bool? Read(int id)
        {
            if (!File.Exists(Path)) return null;

            var xd = new XmlDocument();
            xd.Load(Path);

            var node = xd.SelectSingleNode($"Workflow/workflow[@Id={id}]");
            if (node == null) return null;
            return bool.Parse(node.Attributes["IsCounterSign"].Value);
        }
    }
}