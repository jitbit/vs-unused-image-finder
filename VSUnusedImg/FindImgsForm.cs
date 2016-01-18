using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EnvDTE;
using EnvDTE80;

namespace JitbitSoftware.VSUnusedImg
{
    public partial class FindImgsForm : Form
    {
        public List<ProjectItem> ProjectItems { get; set; }
        private List<ProjectItem> _unusedImages;

        public FindImgsForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            lstImages.Items.Clear();

            toolStripStatusLabel1.Text = "Scan started...";

            //getting all .cs, .aspx, .css, .js files from "projectitems"
            List<string> codefiles = new List<string>();
            foreach (var projectItem in ProjectItems)
            {
                for (short i = 0; i < projectItem.FileCount; i++)
                {
                    string filename = projectItem.FileNames[(short)(i + 1)].ToLower(); //1-based array.. I hate COM
                    if (filename.EndsWith(".cs")
                        || filename.EndsWith(".aspx")
                        || filename.EndsWith(".ascx")
                        || filename.EndsWith(".ashx")
                        || filename.EndsWith(".cshtml")
                        || filename.EndsWith(".css")
                        || filename.EndsWith(".js")
                        || filename.EndsWith(".master"))
                    {
                        codefiles.Add(filename);
                    }
                }
            }

            //getting all iamge filenames from "projectitems"
            List<ProjectItem> images = new List<ProjectItem>();
            foreach (var projectItem in ProjectItems)
            {
                for (short i = 0; i < projectItem.FileCount; i++)
                {
                    string imgname = projectItem.Name.ToLower();
                    if (imgname.EndsWith(".jpg")
                        || imgname.EndsWith(".png")
                        || imgname.EndsWith(".gif"))
                    {
                        images.Add(projectItem);
                    }
                }
            }

			/*
            List<String> ResourceFiles = new List<string>();
            foreach (var projectItem in ProjectItems)
            {
                for (short i = 0; i < projectItem.FileCount; i++)
                {
                    string filename = projectItem.FileNames[(short)(i + 1)].ToLower(); //1-based array.. I hate COM
                    if (filename.EndsWith(".resx"))
                    {
                        ResourceFiles.Add(filename);
                    }
                }
            }

            //Translate all image filenames into Resource usage
            //First find the resource names in Resources.Resx
            Dictionary<String, String> ResourceNames = new Dictionary<String, String>();
            foreach (var img in images)
            {
                bool NextImage = false;
                foreach (var resourcefile in ResourceFiles)
                {
                    System.Xml.XmlDocument X = new System.Xml.XmlDocument();
                    X.Load(resourcefile);
                    var elements = X.GetElementsByTagName("data");
                    foreach (System.Xml.XmlNode element in elements)
                    {
                        String Value = element.ChildNodes[0].InnerText;
                        String FullFileName = Value.Substring(0, Value.IndexOf(';'));
                        String FileName = Path.GetFileName(FullFileName);
                        if (FileName == img.Name)
                        {
                            ResourceNames.Add(element.Attributes["name"].Value, img.Name);
                            NextImage = true;
                        }
                        if (NextImage)
                            break;
                    }
                    if (NextImage)
                        break;
                }
            }
            //Second Find the Strongly Typed global names in Resources.Designer.cs
            Dictionary<String, String> StrongNames = new Dictionary<String, String>();
            foreach (var ResourceName in ResourceNames.Keys)
            {
                bool NextImage = false;
                foreach (var DesignerFile in codefiles.Where(s => s.ToLower().Contains("designer.cs")))
                {
                    String DesignerCode = File.ReadAllText(DesignerFile);
                    Int32 Index = DesignerCode.IndexOf(String.Format("ResourceManager.GetObject(\"{0}\", resourceCulture);",ResourceName));
                    if (Index > -1)
                    {
                        while (Index > 0)
                        {
                            if (DesignerCode.Substring(Index).StartsWith("internal static"))
                            {
                                Int32 StartIndex = DesignerCode.IndexOf(' ', Index + "internal static x".Length);
                                Int32 EndIndex = DesignerCode.IndexOf(' ', StartIndex + 1);
                                String StrongName = DesignerCode.Substring(StartIndex + 1, (EndIndex -1) - StartIndex);
                                StrongNames.Add(ResourceNames[ResourceName], String.Format("Properties.Resources.{0};", StrongName));
                                NextImage = true;
                                break;
                            }
                            Index--;
                        }
                    }
                    if (NextImage)
                        break;
                }
            }
			*/

            _unusedImages = new List<ProjectItem>();

            //ok, now we have a list of filenames and a list of images. lets do the search
            //i know this way of iterating though files for every image is ineffective,will come up with somehting smarter later
            progressBar1.Maximum = codefiles.Count * images.Count;
            int j = 0;
            foreach (var img in images)
            {
                toolStripStatusLabel1.Text = "Processing " + img.Name.ToLower() + "...";
                bool found = false;
                foreach (var file in codefiles)
                {
                    string code = File.ReadAllText(file).ToLower();
                    if (code.IndexOf(img.Name.ToLower()) > -1)
                    {
                        found = true;
                        break;
                    }
					/*
                    else if (code.Contains(StrongNames[img.Name].ToLower()))
                    {
                        found = true;
                        break;
                    }
					*/

                    progressBar1.Value = j;
                    j++;
                    Application.DoEvents();
                }
                if (!found)
                {
                    lstImages.Items.Add(img.Name.ToLower());
                    _unusedImages.Add(img);
                }
            }

            toolStripStatusLabel1.Text = "Finished";
            btnDelete.Enabled = (lstImages.Items.Count > 0);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure? This can't be undone.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes) return;

            foreach (var img in _unusedImages)
            {
                toolStripStatusLabel1.Text = "Deleting " + img.Name.ToLower() + "...";
                img.Delete(); //remove from project
            }

            toolStripStatusLabel1.Text = "Finished";
            btnDelete.Enabled = false;
			btnDeleteSelected.Enabled = false;
		}

		private void btnDeleteSelected_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure? This can't be undone.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes) return;

			for (int i = lstImages.Items.Count - 1; i >= 0; i--)
			{
				if (lstImages.GetSelected(i))
				{
					var img = _unusedImages[i];
					toolStripStatusLabel1.Text = "Deleting " + img.Name.ToLower() + "...";
					img.Delete(); //remove from project
					lstImages.Items.RemoveAt(i);
				}
			}

			toolStripStatusLabel1.Text = "Finished";
			btnDelete.Enabled = false;
			btnDeleteSelected.Enabled = false;
		}

		private void lstImages_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnDeleteSelected.Enabled = lstImages.SelectedIndices.Count > 0;
        }
    }
}
