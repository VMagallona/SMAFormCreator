using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Configuration;
using Spire.Xls;

namespace SMAFormCreator
{
    class SMAFormValidator
    {
        private bool validForm;
        public bool IsValidSMAForm
        {
            get
            {
                return this.validForm;
            }
        }

        private string xml;
        public string Xml
        {
            get
            {
                return this.xml;
            }
            set
            {
                this.xml = value;                
            }

        }

        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }

        }

        private string date;
        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }

        }

        private string type;
        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }

        }

        private string errorMessage;
        public string ErrorMessage
        {
            get
            {
                return this.errorMessage;
            }
        }

        private string filename;
        public string NewFilename
        {
            get { return this.filename; }
        }

        public SMAFormValidator()
        {
            this.validForm = false;
        }

        public SMAFormValidator(string _xml)
        {
            this.validForm = false;
            this.xml = _xml;
            ValidateXML();
        }

        public void SetXml(string xml)
        {
            this.xml = xml;
            ValidateXML();
        }

        private void ValidateXML()
        {
            this.validForm = false;
            // Instantiate an XMLReader and check for the form type attribute. 
            // If it's one of the recognised form types then gather the relevant info and set the members
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(this.xml);
            /*XmlNodeList elemList = doc.GetElementsByTagName("form");
            for (int i = 0; i < elemList.Count; i++)
            {
                string attrVal = elemList[i].Attributes["SuperString"].Value;
            }*/

            string attrVal = doc.SelectSingleNode("/form/@type").Value;

            if (attrVal == "CSC")
            {
                /*attrVal == "PTP" ||
                attrVal == "LED" ||
                attrVal == "FBF" ||)*/

                // set type
                this.type = attrVal;

                // get Name
                XmlNode node = doc.SelectSingleNode("/form/FullName");
                this.name = node.InnerXml.Trim();

                // get Date
                node = doc.SelectSingleNode("/form/Created_date");
                
                DateTime dt = DateTime.Parse(node.InnerText.Trim());
                this.date = dt.ToString("yyyy/MM/dd");// + " " + dt.ToShortTimeString();

                this.validForm = true;

                SetFilename();
            }
            else if (attrVal == "CDF")
            {
                /*attrVal == "PTP" ||
                attrVal == "LED" ||
                attrVal == "FBF" ||)*/

                // set type
                this.type = attrVal;

                // get Name
                XmlNode node = doc.SelectSingleNode("/form/txtName");
                this.name = node.InnerXml.Trim();

                // get Date
                node = doc.SelectSingleNode("/form/Created_date");

                DateTime dt = DateTime.Parse(node.InnerText.Trim());
                this.date = dt.ToString("yyyy/MM/dd");// + " " + dt.ToShortTimeString();

                this.validForm = true;

                SetFilename();
            }
            else
            {
                errorMessage = "Unknown form type'" + attrVal + "'. ";
            }
        }

        public bool ClientFolderExists()
        {
            return Directory.Exists(ClientFolder());            
        }
        
        public bool ClientFileExists()
        {
            return File.Exists(NewClientFile());
        }

        private void SetFilename()
        {
            // split the name
            string abbrevName = "<ClientName>";
            if (this.name.Length > 0)
            {
                string [] names = this.name.Split(' ');
                abbrevName = names[0].Substring(0, 2);

                if (names.Length >= 2)
                {                   
                    abbrevName += names[names.Length - 1].Substring(0, 2);
                }
            }

            this.filename = string.Format("{0}_{1}_{2}.xlsx", this.type, this.date.Replace("/",""), abbrevName);
        }

        private string ClientFolder()
        {
            return string.Format(@"{0}\{1}", Properties.Settings.Default.ClientFormsFolder, this.name);
        }

        private string NewClientFile()
        {
            return string.Format(@"{0}\{1}", ClientFolder(), this.filename);
        }

        public bool CreateNewFile()
        {            
            if (!ClientFolderExists())
            {
                Directory.CreateDirectory(ClientFolder());
            }

            // write to the new xlsx file
            return WriteXMLtoNewFile();            
        }

        private bool WriteXMLtoNewFile()
        {

            /*
             <?xml version="1.0"?><form type="CSC"><FullName>vincent magallona</FullName><PhysicalText></PhysicalText><PhysicalRating>0</PhysicalRating><EmotionalText></EmotionalText><EmotionalRating>0</EmotionalRating><StressLevelText></StressLevelText><StressLevelRating>0</StressLevelRating><OtherText></OtherText><OtherRating>0</OtherRating><bPregnancy>false</bPregnancy><txtPregnancy></txtPregnancy><bActiveSkinCondition>false</bActiveSkinCondition><txtActiveSkinCondition></txtActiveSkinCondition><bBloodPressure>false</bBloodPressure><txtBloodPressure></txtBloodPressure><bHeartIssues>false</bHeartIssues><txtHeartIssues></txtHeartIssues><bRecentSurgery>false</bRecentSurgery><txtRecentSurgery></txtRecentSurgery><bDiabetes>false</bDiabetes><txtDiabetes></txtDiabetes><bEpilepsy>false</bEpilepsy><txtEpilepsy></txtEpilepsy><bCompromisedImmuneSystem>false</bCompromisedImmuneSystem><txtCompromisedImmuneSystem></txtCompromisedImmuneSystem><bEatingDisorder>false</bEatingDisorder><txtEatingDisorder></txtEatingDisorder><bPacemaker>false</bPacemaker><txtPacemaker></txtPacemaker><bNeedleFear>false</bNeedleFear><txtNeedleFear></txtNeedleFear><bOtherConditions>false</bOtherConditions><txtOtherConditions></txtOtherConditions><txtOtherInformation></txtOtherInformation><bTreatment_Stress>false</bTreatment_Stress><bTreatment_backPain>false</bTreatment_backPain><bTreatment_Headaches>false</bTreatment_Headaches><bTreatment_Detox>false</bTreatment_Detox><bTreatment_Hayfever>false</bTreatment_Hayfever><bDisclosureConfirmation>true</bDisclosureConfirmation><bTandCConfirmation>true</bTandCConfirmation><txtDob>01/07/1976</txtDob><txtContactNumber>1324567896541</txtContactNumber><ID>4193b00d-2d05-40d0-b62e-74e20c44a578</ID><Created_date>2018-07-02T11:39:00Z</Created_date><Updated_date>2018-07-02T11:39:00Z</Updated_date><Owner>0242589d-db99-42e9-91ac-22cda13e0d54</Owner><Email>v@m.com</Email></form>
             * */
            bool bReturn = true;

            try
            {
                string templateFile = "";

                switch (this.type)
                {
                    case "CSC":
                        templateFile = string.Format(@"{0}\{1}", Properties.Settings.Default.CSCTemplateLocation, Properties.Settings.Default.CSCTemplateName);
                        break;
                    case "CDF":
                        templateFile = string.Format(@"{0}\{1}", Properties.Settings.Default.CDFTemplateLocation, Properties.Settings.Default.CDFTemplateName);
                        break;
                    default:
                        bReturn = false;
                        break;
                }

                if (bReturn)
                {
                    //Initialize a new Workboook object
                    Workbook workbook = new Workbook();

                    //Load workbook 
                    workbook.LoadFromFile(templateFile);
                    
                    Worksheet ws = workbook.Worksheets["EMAILPaste"];
                    string test = ws.Range["A2"].Text;
                    ws.Range["A2"].Text = this.xml;

                    //Save workbook to disk
                    workbook.SaveToFile(NewClientFile());

                    System.Diagnostics.Process.Start(NewClientFile());
                }
            }
            catch (Exception ex)
            {
                bReturn = false;
            }

            return bReturn;
        }

    }

    
}
