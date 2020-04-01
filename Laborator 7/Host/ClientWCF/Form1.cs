using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FileProperty;

namespace ClientWCF
{
    /// <summary>
    /// Nume si prenume: Cocei Tiberiu
    /// Laborator: Miercuri 16-18
    /// Tema proiect: MyPhotos Proiectul 1
    /// Data predare proiect: 16.03.2020
    /// Declaratie: Subsemnatul Cocei Tiberiu declar pe propria raspundere 
    /// ca acest cod nu a fost copiat din Internet sau din alte surse.
    /// Bibliografie, surse de inspiratie:
    /// Rolul clasei: initializarea interfetei si tratarea evenimentelor ce au loc.
    /// Permite utilizatorului sa se foloseasca de API-uri prin intermediul unei 
    /// interfete grafice. De asemenea, permite deschiderea fisierelor selectate.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Aceasta lista de obiecte de tip Property va memora toate propietatile
        /// inainte de a fi afisate pe interfata. Necesara pentru a sti ce obiecte
        /// vor fi modificate dupa selectarea din lista de pe interfata de utilizator.
        /// </summary>
        private List<Property> Properties;
        /// <summary>
        /// Aceasta lista de obiecte de tip File va memora toate fisierele
        /// inainte de a fi afisate pe interfata. Necesara pentru a sti ce obiecte
        /// vor fi modificate dupa selectarea din lista de pe interfata de utilizator.
        /// </summary>
        private List<FileProperty.File> Files;
        /// <summary>
        /// Obiect auxiliar pentru a memora intr-o metoda detalii despre fisier, ce apoi
        /// vor fi folosite in alta metoda.
        /// </summary>
        private FileProperty.File FileToAdd;
        private FilePropertyClient FilePropertyClient;
        
        public Form1()
        {
            InitializeComponent();
            Files = new List<FileProperty.File>();
            Properties = new List<Property>();
            FilePropertyClient = new FilePropertyClient();
            FileToAdd = null;
        }

        /// <summary>
        /// Cand e incarcata initial interfata, listele de fisiere si propietati vor fi populate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdatePropertyList();
            UpdateFileList();
        }

        /// <summary>
        /// Cand butonul de modificare fisier e apasat, se verifica cate fisiere au fost selectate.
        /// Daca este unul singur, atunci fisierul va fi modificat in functie de textul din
        /// path, nume si descriere fisier + propietatile selectate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeButton_Click(object sender, EventArgs e)
        {
            var fileIndices = fileView.CheckedIndices.Cast<int>();
            if (fileIndices.Count() != 1)
                return;

            List<int> propertiesToChange = new List<int>();
            var propertyIndices = propertyView.CheckedIndices.Cast<int>();
            foreach (int property in propertyIndices)
            {
                propertiesToChange.Add(Properties[property].Id);
            }

            var file = new FileProperty.File()
            {
                Id = Files[fileIndices.ElementAt(0)].Id,
                Name = nameBox.Text,
                Description = fileDescriptionBox.Text,
                Path = filePathBox.Text
            };
            FilePropertyClient.ModifyFile(file, propertiesToChange.ToArray());

            nameBox.Text = "";
            fileDescriptionBox.Text = "";
            filePathBox.Text = "";
            UpdateFileList();
        }

        /// <summary>
        /// Cand butonul de delete e apasat, toate fisierele selectate isi vor avea
        /// id-ul pus intr-o lista ce va fi trimis catre API.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            List<int> filesToMark = new List<int>();
            var fileIndices = fileView.CheckedIndices.Cast<int>();
            foreach (int file in fileIndices)
            {
                filesToMark.Add(Files[file].Id);
            }
            FilePropertyClient.MarkForDeletion(filesToMark.ToArray());
            UpdateFileList();
        }

        /// <summary>
        /// Cand butonul de confirm delete e apasat, metoda corespunzatoare din API va fi apelata.
        /// De asemnea, se va updata lista de fisiere.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmButton_Click(object sender, EventArgs e)
        {
            FilePropertyClient.FinishDeletion(false);
            UpdateFileList(true);
        }

        /// <summary>
        /// Cand butonul de cancel delete e apasat, metoda corespunzatoare din API va fi apelata.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            FilePropertyClient.FinishDeletion(true);
            UpdateFileList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Daca descrierea propietatii nu este goala, propietatea cu acea descriere 
        /// va fi adaugata in baza de date. De asemenea, lista de propietati va fi updatata.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void propertyDescButton_Click(object sender, EventArgs e)
        {
            string propertyDescription = textBox1.Text;
            if (propertyDescription == null || propertyDescription.Length == 0)
                return;
            FilePropertyClient.AddProperty(propertyDescription);
            textBox1.Text = "";
            UpdatePropertyList();
        }

        /// <summary>
        /// Cand butonul de selectare fisier e apasat, se va deschide File Explorer-ul.
        /// Exista un filtru ca sa apara numai fisiere de tip imagine si video.
        /// Odata selectat, atributul FileToAdd va avea campurile modificate 
        /// in functie de detaliile fisierului.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png; *.mp4; *.avi; *.webm; *.mkv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathBox.Text = openFileDialog.FileName;
                FileToAdd = new FileProperty.File()
                {
                    Path = openFileDialog.FileName,
                    Size = new FileInfo(openFileDialog.FileName).Length,
                    CreationDate = DateTime.Now
                };

                foreach (ListViewItem property in propertyView.Items)
                {
                    property.Checked = false;
                }
            }
        }

        private void filePathBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void fileDescriptionBox_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Cand butonul de adaugare fisier e apasat, se va verifica daca text boxurile
        /// relevante sunt goale. Daca nu sunt, atunci fisierul va fi adaugat in baza de date
        /// folosind API-ul corespunzator, text box-urile vor fi golite iar lista de fisiere
        /// updatata.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addFileButton_Click(object sender, EventArgs e)
        {
            if (FileToAdd == null || nameBox.Text == null || nameBox.Text.Length == 0 ||
                fileDescriptionBox.Text == null || fileDescriptionBox.Text.Length == 0)
                return;
            FileToAdd.Name = nameBox.Text;
            FileToAdd.Description = fileDescriptionBox.Text;

            List<int> propertiesToAdd = new List<int>();
            var propertyIndices = propertyView.CheckedIndices.Cast<int>();
            foreach (int property in propertyIndices)
            {
                propertiesToAdd.Add(Properties[property].Id);
            }

            FilePropertyClient.AddFile(FileToAdd, propertiesToAdd.ToArray());
            propertyView.SelectedItems.Clear();
            filePathBox.Text = "";
            nameBox.Text = "";
            fileDescriptionBox.Text = "";
            UpdateFileList();
        }

        /// <summary>
        /// Cand utilizatorul apasa pe un fisier din lista, atunci propietatile
        /// sale vor fi selectate in lista de propietati.
        /// Acest lucru e realizat folosind API-ul de obtinere a propietatilor
        /// pentru un fisier dat.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fileView.SelectedItems.Count == 0)
                return;

            foreach (ListViewItem property in propertyView.Items)
            {
                property.Checked = false;
            }

            int fileIndex = Files[fileView.Items.IndexOf(fileView.SelectedItems[0])].Id;
            var properties = FilePropertyClient.GetFileProperties(fileIndex);

            int index = 0;
            foreach (ListViewItem property in propertyView.Items)
            {
                if (properties.Where(x => x.Id == Properties[index].Id).Count() != 0)
                    property.Checked = true;
                index++;
            }
        }

        private void propertyView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Cand butonul de cautare fisiere e apasat, cautarea filtrata va avea loc
        /// folosind propietatile selectate de catre utilizator din lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchButton_Click(object sender, EventArgs e)
        {
            UpdateFileList(true);
        }

        /// <summary>
        /// Cand butonul de stergere de propietati e apasat, propietatile selectate
        /// vor fi sterse. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void propertyDeleteButton_Click(object sender, EventArgs e)
        {
            List<int> propertiesToRemove = new List<int>();
            var propertyIndices = propertyView.CheckedIndices.Cast<int>();
            foreach (int property in propertyIndices)
            {
                propertiesToRemove.Add(Properties[property].Id);
            }
            FilePropertyClient.DeleteProperties(propertiesToRemove.ToArray());
            UpdatePropertyList();
        }

        /// <summary>
        /// Cand lista de propietati este updatata, toate propietatile sunt luate din
        /// baza de date si descrierea lor afisata.
        /// </summary>
        private void UpdatePropertyList()
        {
            propertyView.Items.Clear();
            Properties = FilePropertyClient.GetAllProperties().ToList<Property>();
            foreach (var property in Properties)
            {
                propertyView.Items.Add(new ListViewItem(new string[] { property.Id.ToString(), property.Description }));
            }
        }

        /// <summary>
        /// Cand lista de fisiere este updatata, fisierele sunt luate in functie de
        /// propietatile selectate de utilizator si de valoarea boolean-ului filtered.
        /// Daca path-ul obtinut din baza de date nu mai este prezent pe calculator,
        /// atunci fisierul respectiv isi va avea informatiile redate cu rosu.
        /// </summary>
        /// <param name="filtered">Daca este true, atunci cautarea va fi filtrata.</param>
        private void UpdateFileList(bool filtered = false)
        {
            fileView.Items.Clear();
            List<int> propertiesToSearchFor = new List<int>();
            var propertyIndices = propertyView.CheckedIndices.Cast<int>();
            if (filtered)
            {
                foreach (int property in propertyIndices)
                {
                    propertiesToSearchFor.Add(Properties[property].Id);
                }
            }
            Files = FilePropertyClient.FileSearch(propertiesToSearchFor.ToArray()).ToList<FileProperty.File>();
            foreach (var file in Files)
            {
                var listItem = new ListViewItem(new string[] { file.Id.ToString(), file.Name, file.Description, file.Path,
                                                                   file.Size.ToString(), file.CreationDate.ToString(), file.ToDelete.ToString() });
                if (!System.IO.File.Exists(file.Path))
                {
                    listItem.ForeColor = Color.Red;
                }
                fileView.Items.Add(listItem);
            }
        }

        /// <summary>
        /// Cand butonul de deschidere fisiere e apasat, si un singur fisier
        /// are checkbox-ul selectat, se va deschide.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileButton_Click(object sender, EventArgs e)
        {
            var fileIndices = fileView.CheckedIndices.Cast<int>();
            if (fileIndices.Count() != 1)
                return;

            string path = Files[fileIndices.ElementAt(0)].Path;
            string extension = Path.GetExtension(path);
            string[] imageExtensions = new string[3] { ".jpg", ".jpeg", ".png" };

            if (imageExtensions.Contains(extension))
            {
                pictureBox1.ImageLocation = path;
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                Process.Start(@path);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Se va alege din File Explorer un fisier .txt, si in el
        /// se vor salva informatii despre fisierele si propietatile
        /// lor din lista de fisierea filtrata.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text|*.txt|All|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string toWrite = "";

                foreach (var file in Files)
                {
                    toWrite += "Name: " + file.Name + " - Description: " + file.Description + " - Path: " + file.Path + " - Size: " + file.Size.ToString() +
                        " - Date: " + file.CreationDate.ToString() + " - To Delete: " + file.ToDelete.ToString() + "\n";
                    var properties = FilePropertyClient.GetFileProperties(file.Id);
                    foreach (var property in properties)
                        toWrite += "\t" + property.Description + "\n";
                }

                System.IO.File.WriteAllText(filePath, toWrite);
            }
        }
    }
}
