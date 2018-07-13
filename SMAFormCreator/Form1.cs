using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMAFormCreator
{
    public partial class Form1 : Form
    {
        private SMAFormValidator smaFormValidator = null;

        public Form1()
        {
            InitializeComponent();

            smaFormValidator = new SMAFormValidator();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Check if the text is XML.
            // Parse it and extract, type, name and date for display purposes
            // 1) Check if the name exists in the client forms area. Give description of what will happen if the "Create Form" button is pressed. i.e. 
            //    Form will be created in the existing user folder or a new user folder will be created.
            try
            {
                smaFormValidator.SetXml(xmlSource.Text);
                //smaFormValidator.SetXml("<?xml version=\"1.0\"?><form type=\"CSC\"><FullName>Zenette Abrahams </FullName><PhysicalText>Tiredness/adrenals - 8 Hair and skin - 5 Thyroid inflammation - 5</PhysicalText><PhysicalRating>0</PhysicalRating><EmotionalText>Low mood - 4 Anxiety - 5</EmotionalText><EmotionalRating>0</EmotionalRating><StressLevelText></StressLevelText><StressLevelRating>4</StressLevelRating><OtherText></OtherText><OtherRating>0</OtherRating><bPregnancy>false</bPregnancy><txtPregnancy></txtPregnancy><bActiveSkinCondition>false</bActiveSkinCondition><txtActiveSkinCondition></txtActiveSkinCondition><bBloodPressure>false</bBloodPressure><txtBloodPressure></txtBloodPressure><bHeartIssues>false</bHeartIssues><txtHeartIssues></txtHeartIssues><bRecentSurgery>false</bRecentSurgery><txtRecentSurgery></txtRecentSurgery><bDiabetes>false</bDiabetes><txtDiabetes></txtDiabetes><bEpilepsy>false</bEpilepsy><txtEpilepsy></txtEpilepsy><bCompromisedImmuneSystem>false</bCompromisedImmuneSystem><txtCompromisedImmuneSystem></txtCompromisedImmuneSystem><bEatingDisorder>false</bEatingDisorder><txtEatingDisorder></txtEatingDisorder><bPacemaker>false</bPacemaker><txtPacemaker></txtPacemaker><bNeedleFear>false</bNeedleFear><txtNeedleFear></txtNeedleFear><bOtherConditions>true</bOtherConditions><txtOtherConditions>Hypothyroidism</txtOtherConditions><txtOtherInformation></txtOtherInformation><bTreatment_Stress>true</bTreatment_Stress><bTreatment_backPain>false</bTreatment_backPain><bTreatment_Headaches>false</bTreatment_Headaches><bTreatment_Detox>false</bTreatment_Detox><bTreatment_Hayfever>false</bTreatment_Hayfever><bDisclosureConfirmation>true</bDisclosureConfirmation><bTandCConfirmation>true</bTandCConfirmation><txtDob>22/12/1975</txtDob><txtContactNumber>07824446055</txtContactNumber><ID>d12b1800-f5c8-4580-a6e0-e07280f51e48</ID><Created_date>2018-05-24T17:33:48Z</Created_date><Updated_date>2018-05-24T17:33:48Z</Updated_date><Owner>undefined</Owner><Email>zenette_a@yahoo.com</Email></form>");

                if (smaFormValidator.IsValidSMAForm)
                {
                    label3.Text = String.Format("'{0}' form by '{1}' ({2})",
                        smaFormValidator.Type,
                        smaFormValidator.Name,
                        smaFormValidator.Date);
                }
                else
                {
                    label3.Text = "Error: " + smaFormValidator.ErrorMessage;
                }
            }
            catch(Exception ex)
            {
                label3.Text = "Error: " + ex.Message;
            }

            UpdateInfoBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool bContinue = false;
            if (smaFormValidator.ClientFileExists())
            {
                DialogResult dr = MessageBox.Show(smaFormValidator.NewFilename + " already exists. Overwrite?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    bContinue = true;
                }
            }
            else
            {
                bContinue = true;
            }

            if (bContinue)
            {
                if (smaFormValidator.CreateNewFile())
                {
                    resultLabel.Text = smaFormValidator.NewFilename + " created successfully";
                }
                else
                {
                    resultLabel.Text = smaFormValidator.NewFilename + " creation FAILED. Ask Vince for help.";
                }
            }
        }

        private void UpdateInfoBox()
        {
            textBox2.Text = "";

            if (smaFormValidator.IsValidSMAForm)
            {
                bool bExistingClient = smaFormValidator.ClientFolderExists();
                bool bExistingFile = smaFormValidator.ClientFileExists();

                System.Collections.ArrayList lines = new System.Collections.ArrayList();

                if (bExistingClient)
                {
                    if (bExistingFile)
                    {
                        lines.Add(string.Format("{0} is an existing client but this form {1} already exists on the file system", smaFormValidator.Name, smaFormValidator.NewFilename));
                        lines.Add(string.Format("Pressing 'CREATE FORM' could overwrite the existing file."));
                    }
                    else
                    {
                        lines.Add(string.Format("{0} is an existing client.", smaFormValidator.Name));
                        lines.Add(string.Format("Press 'CREATE FORM' to create {0} on the file system.", smaFormValidator.NewFilename));                            
                    }
                }
                else
                {
                    lines.Add(string.Format("{0} is not an existing client.", smaFormValidator.Name));
                    lines.Add(string.Format("Press 'CREATE FORM' to create a new client folder and file {0} on the file system.", smaFormValidator.NewFilename));
                }

                textBox2.Lines = (string[])lines.ToArray(typeof(string));
                formType.Text = smaFormValidator.Type;
                clientName.Text = smaFormValidator.Name;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void changeClientName_Click(object sender, EventArgs e)
        {
            // get the name from the text box and replace the existing name with it.
            xmlSource.Text = xmlSource.Text.Replace(string.Format(">{0}", smaFormValidator.Name), string.Format(">{0}", clientName.Text));
        }

        private void changeFormType_Click(object sender, EventArgs e)
        {
            // get the type from the combo box and replace the existing type with it.
            xmlSource.Text = xmlSource.Text.Replace(string.Format("type=\"{0}\"", smaFormValidator.Type), string.Format("type=\"{0}\"", formType.Text));
        }
    }
}
