using PatternBase.Model;
using PatternBase.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternBase
{
    public partial class FrmNewPattern : ObserverForm
    {
        private bool exitform = false;
        private OpenFileDialog openFileDialog;
        public bool editScreen = false;
        public bool showScreen = false;
        public Pattern editPattern;

        public FrmNewPattern(ObservableForm reference)
        {
            InitializeComponent();
            this.receiver = reference;

            this.FormClosing += this.FrmNewPattern_FormClosing;

            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();

            // Set the file dialog to filter for graphics files. 
            openFileDialog.Filter =
                "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
                "All files (*.*)|*.*";

            this.openFileDialog.Title = "Browse image";
        }

        private void FrmNewPattern_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (!exitform)
            {
                // Display a MsgBox asking the user to save changes or abort. 
                string message = "";
                if (editScreen)
                {
                    message = "Cancel editing patterm?";
                }
                else
                {
                    message = "Cancel creating new pattern?";
                }
                if (MessageBox.Show(message, "PatternBase",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    exitform = true;
                }
                else
                {
                    // Cancel the Closing event from closing the form.
                    e.Cancel = true;
                    // Call method to save file...
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Pattern patternId = new Pattern();
            Pattern pattern = new Pattern();
            if (editScreen)
            {
                foreach (Scope scope in editPattern.getScopeList())
                {
                    ComponentModel patternForRemove;
                    patternForRemove = scope.GetSubComponentById(editPattern.getId());
                    scope.RemoveSubComponent(patternForRemove);
                }
                foreach (Purpose purpose in editPattern.getPurposeList())
                {
                    ComponentModel patternForRemove;
                    patternForRemove = purpose.GetSubComponentById(editPattern.getId());
                    purpose.RemoveSubComponent(patternForRemove);
                }

                editPattern.cleanPurpose();
                editPattern.cleanScope();
                pattern = editPattern;
            }
            else
            {
                pattern.setId(Program.database.getId());
                Program.database.addPattern(pattern);
            }

            pattern.setName(txtName.Text);
            pattern.setDescription(txtDescription.Text);
            pattern.setProblem(txtProblem.Text);
            pattern.setConsequence(txtConsequence.Text);
            pattern.setSolution(txtSolution.Text);
            patternId.setId(pattern.getId());
            pattern.setImage(pbImage.Image);

            foreach (KeyValue parentItemPurpose in lbParrentPurpose.SelectedItems)
            {
                Purpose parentPurpose = Program.database.getPurposeById(Convert.ToInt32(parentItemPurpose.key));
                pattern.addPurpose(parentPurpose);
                if(parentPurpose != null)
                parentPurpose.AddSubComponent(patternId);
            }

            foreach (KeyValue parentItemScope in lbParrentScope.SelectedItems)
            {
                Scope parentScope = Program.database.getScopeById(Convert.ToInt32(parentItemScope.key));
                pattern.addScope(parentScope);
                if (parentScope != null)
                parentScope.AddSubComponent(patternId);
            }

            this.receiver.Updater();
            exitform = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmNewPattern_Load(object sender, EventArgs e)
        {
            Scope scope = Program.database.getHeadScope();
            fetchSubCategories(scope, "");
            lbParrentScope.DisplayMember = "value";
            lbParrentScope.ValueMember = "key";

            Purpose purpose = Program.database.getHeadPurpose();
            fetchSubCategories(purpose, "");
            lbParrentPurpose.DisplayMember = "value";
            lbParrentPurpose.ValueMember = "key";

            if (editScreen)
            {
                btnAdd.Text = "Edit";
                this.Text = "Edit Pattern";
                txtName.Text = editPattern.getName();
                txtDescription.Text = editPattern.getDescription();
                txtProblem.Text = editPattern.getProblem();
                pbImage.Image = editPattern.getImage();

                foreach (Scope scopeSelect in editPattern.getScopeList())
                {
                    for (int i = 0; i < lbParrentScope.Items.Count; i++)
                    {
                        KeyValue keyValue = (KeyValue)lbParrentScope.Items[i];
                        if (keyValue.key == scopeSelect.getId().ToString())
                        {
                            lbParrentScope.SetSelected(i, true);

                        }
                    }
                }

                foreach (Purpose purposeSelect in editPattern.getPurposeList())
                {
                    for (int i = 0; i < lbParrentPurpose.Items.Count; i++)
                    {
                        KeyValue keyValue = (KeyValue)lbParrentPurpose.Items[i];
                        if (keyValue.key == purposeSelect.getId().ToString())
                        {
                            lbParrentPurpose.SetSelected(i, true);

                        }
                    }
                }
            }
            else
            {
                btnDelete.Visible = false;
            }

            if (showScreen)
            {
                btnDelete.Visible = false;
                btnAdd.Visible = false;
                btnBrowse.Visible = false;
                txtBrowse.Visible = false;
                btnCancel.Text = "Close";
                this.Text = "Show Pattern";
                exitform = true;
                txtName.ReadOnly = true;
                txtDescription.ReadOnly = true;
                txtProblem.ReadOnly = true;
                txtConsequence.ReadOnly = true;
                txtSolution.ReadOnly = true;
            }
        }

        private void fetchSubCategories(Scope sco, string prefix)
        {
            KeyValue keyValue = new KeyValue();
            keyValue.key = sco.getId().ToString();
            keyValue.value = prefix + sco.getName();
            lbParrentScope.Items.Add(keyValue);
            foreach (ComponentModel sc in sco.getSubComponents())
            {
                if (sc.GetType() == typeof(Scope)) {
                    this.fetchSubCategories((Scope)sc, "- " + prefix);
                }
            }
        }

        private void fetchSubCategories(Purpose purp, string prefix)
        {
            KeyValue keyValue = new KeyValue();
            keyValue.key = purp.getId().ToString();
            keyValue.value = prefix + purp.getName();
            lbParrentPurpose.Items.Add(keyValue);
            foreach (ComponentModel pur in purp.getSubComponents())
            {
                if (pur.GetType() == typeof(Purpose)) {
                    this.fetchSubCategories((Purpose)pur, "- " + prefix);
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                // Read the files 
                foreach (String file in openFileDialog.FileNames)
                {
                    // Create a PictureBox. 
                    try
                    {
                        txtBrowse.Text = file;
                        Image loadedImage = Image.FromFile(file);
                        Bitmap newImage = new Bitmap(258, 176);
                        using (Graphics gr = Graphics.FromImage(newImage))
                        {
                            gr.SmoothingMode = SmoothingMode.HighQuality;
                            gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            gr.DrawImage(loadedImage, new Rectangle(0, 0, 258, 176));
                        }
                        pbImage.Image = newImage;
                    }
                    catch (SecurityException ex)
                    {
                        // The user lacks appropriate permissions to read files, discover paths, etc.
                        MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                            "Error message: " + ex.Message + "\n\n" +
                            "Details (send to Support):\n\n" + ex.StackTrace
                        );
                    }
                    catch (Exception ex)
                    {
                        // Could not load the image - probably related to Windows file system permissions.
                        MessageBox.Show("Cannot display the image: " + file.Substring(file.LastIndexOf('\\'))
                            + ". You may not have permission to read the file, or " +
                            "it may be corrupt.\n\nReported error: " + ex.Message);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (editScreen)
            {
                foreach (Scope scope in editPattern.getScopeList())
                {
                    ComponentModel patternForRemove;
                    patternForRemove = scope.GetSubComponentById(editPattern.getId());
                    if (patternForRemove != null)
                    scope.RemoveSubComponent(patternForRemove);
                }
                foreach (Purpose purpose in editPattern.getPurposeList())
                {
                    ComponentModel patternForRemove;
                    patternForRemove = purpose.GetSubComponentById(editPattern.getId());
                    if (patternForRemove != null)
                    purpose.RemoveSubComponent(patternForRemove);
                }

                editPattern.cleanPurpose();
                editPattern.cleanScope();
                Program.database.removePattern(editPattern);

                this.receiver.Updater();
                exitform = true;
                this.Close();
            }
        }
    }
}
