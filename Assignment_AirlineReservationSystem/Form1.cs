using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_AirlineReservationSystem
{
    public partial class Form1 : Form
    {
        const string AIRBUS = "Airbus";
        const string BOEING = "Boeing";

        const string FIRST_ClASS = "First";
        const string BUSINESS_ClASS = "Business";
        const string ECONOMY_ClASS = "Economy";

        const string AVAILABLE = "available";
        const string OCCUPID = "occupid";

        string[,] airbusFirstSeats = new string[5, 4];
        string[,] airbusBusinessSeats = new string[6, 6];
        string[,] airbusEconomySeats = new string[24, 10];

        string[,] boeingFirstSeats_OneFloor = new string[5, 4];
        string[,] boeingFirstSeats_SecondFloor = new string[5, 4];
        string[,] boeingBusinessSeats = new string[6, 6];
        string[,] boeingEconomySeats = new string[34, 10];

        Button[] airbusButtons = new Button[296];
        Button[] boeingButtons = new Button[396];
        Button[] boeingButtons_SecondFloor = new Button[20];

        public Form1()
        {
            InitializeComponent();

            // initial form

            // airplane company
            comboBox1.Items.Add(AIRBUS);
            comboBox1.Items.Add(BOEING);

            comboBox1.SelectedIndex = 0;

            // kind of class
            comboBox2.Items.Add(FIRST_ClASS);
            comboBox2.Items.Add(BUSINESS_ClASS);
            comboBox2.Items.Add(ECONOMY_ClASS);

            comboBox2.SelectedIndex = 0;

            // floor
            comboBox3.Items.Add("1");
            comboBox3.Items.Add("2");
            comboBox3.SelectedIndex = 0;

            initilizeReserveSeats();

            createLabelsForAirline();

            createButtonsForAirline(AIRBUS, 1, 35);
            createButtonsForAirline(BOEING, 1, 45);
            createButtonsForAirline(BOEING, 2, 5);
        }

        private void initilizeReserveSeats()
        {
            int i, j;

            // airbus
            for (i = 0; i < airbusFirstSeats.GetLength(0); i++)
            {
                for (j = 0; j < airbusFirstSeats.GetLength(1); j++)
                {
                    airbusFirstSeats[i, j] = AVAILABLE;
                }
            }

            for (i = 0; i < airbusBusinessSeats.GetLength(0); i++)
            {
                for (j = 0; j < airbusBusinessSeats.GetLength(1); j++)
                {
                    airbusBusinessSeats[i, j] = AVAILABLE;
                }
            }

            for (i = 0; i < airbusEconomySeats.GetLength(0); i++)
            {
                for (j = 0; j < airbusEconomySeats.GetLength(1); j++)
                {
                    airbusEconomySeats[i, j] = AVAILABLE;
                }
            }


            // boeing
            for (i = 0; i < boeingFirstSeats_OneFloor.GetLength(0); i++)
            {
                for (j = 0; j < boeingFirstSeats_OneFloor.GetLength(1); j++)
                {
                    boeingFirstSeats_OneFloor[i, j] = AVAILABLE;
                }
            }

            for (i = 0; i < boeingFirstSeats_SecondFloor.GetLength(0); i++)
            {
                for (j = 0; j < boeingFirstSeats_SecondFloor.GetLength(1); j++)
                {
                    boeingFirstSeats_SecondFloor[i, j] = AVAILABLE;
                }
            }

            for (i = 0; i < boeingBusinessSeats.GetLength(0); i++)
            {
                for (j = 0; j < boeingBusinessSeats.GetLength(1); j++)
                {
                    boeingBusinessSeats[i, j] = AVAILABLE;
                }
            }

            for (i = 0; i < boeingEconomySeats.GetLength(0); i++)
            {
                for (j = 0; j < boeingEconomySeats.GetLength(1); j++)
                {
                    boeingEconomySeats[i, j] = AVAILABLE;
                }
            }
        }

        private void createLabelsForAirline()
        {

            for (int k = 0; k < 10; k++)
            {
                Label tmpLabel1 = new Label();
                Label tmpLabel2 = new Label();
                

                tmpLabel1.Left = 83 + k * 20;
                tmpLabel1.Top = 80;
                tmpLabel1.Size = new Size(20, 20);
                tmpLabel1.Text = (k + 1).ToString();

                tmpLabel2.Left = 83 + k * 20;
                tmpLabel2.Top = 80;
                tmpLabel2.Size = new Size(20, 20);
                tmpLabel2.Text = (k + 1).ToString();
                

                tabPage2.Controls.Add(tmpLabel1);
                tabPage3.Controls.Add(tmpLabel2);


                if (0 <= k && k <= 3) { 
                    Label tmpLabel3 = new Label();

                    tmpLabel3.Left = 83 + k * 20;
                    tmpLabel3.Top = 80;
                    tmpLabel3.Size = new Size(20, 20);
                    tmpLabel3.Text = (k + 1).ToString();
                
                    tabPage4.Controls.Add(tmpLabel3);
                }
            }
        }

        private void createButtonsForAirline(string pCompanyName, int pFloor, int pMaxRow)
        {
            int top = 100;
            int left = 50;
            int columnSeat = 0;
            int buttonIdx = 0;
            string showStr = "";
            string[,] targetSeatsArr;
            int adjustIdx = 0;

            for (int i = 0; i < pMaxRow; i++)
            {
                // airbus
                Label label1 = new Label();

                // boeing
                Label label2 = new Label();

                Label label3 = new Label();

                label1.Left = left;
                label1.Top = top + i * 20;
                label1.Size = new Size(20, 20);

                label2.Left = left;
                label2.Top = top + i * 20;
                label2.Size = new Size(20, 20);

                label3.Left = left;
                label3.Top = top + i * 20;
                label3.Size = new Size(20, 20);

                label1.Text = (i + 1).ToString();
                label2.Text = (i + 1).ToString();
                label3.Text = (i + 1).ToString();

                if (0 <= i && i <= 4)
                {
                    tabPage4.Controls.Add(label3);
                }

                if (0 <= i && i <= 34)
                {
                    tabPage2.Controls.Add(label1);
                }

                tabPage3.Controls.Add(label2);

                targetSeatsArr = null;

                if (i == 5 || i == 11)
                {
                    left = 50;
                    top = 100;
                }

                switch (pCompanyName)
                {
                    case AIRBUS:
                        if (0 <= i && i <= 4)
                        {
                            targetSeatsArr = airbusFirstSeats;
                            columnSeat = 4;
                            adjustIdx = getAdjustIndexByClass(FIRST_ClASS) - 1;
                        }
                        else if (5 <= i && i <= 10)
                        {
                            targetSeatsArr = airbusBusinessSeats;
                            columnSeat = 6;
                            adjustIdx = getAdjustIndexByClass(BUSINESS_ClASS) - 1;
                        }
                        else
                        {
                            targetSeatsArr = airbusEconomySeats;
                            columnSeat = 10;
                            adjustIdx = getAdjustIndexByClass(ECONOMY_ClASS) - 1;
                        }
                        break;

                    case BOEING:
                        if (0 <= i && i <= 4)
                        {
                            if (pFloor == 1) {
                                targetSeatsArr = boeingFirstSeats_OneFloor;

                            }
                            else if (pFloor == 2)
                            {
                                targetSeatsArr = boeingFirstSeats_SecondFloor;
                            }
                            else
                            {
                                return;
                            }
                            columnSeat = 4;
                            adjustIdx = getAdjustIndexByClass(FIRST_ClASS) - 1;
                        }
                        else if (5 <= i && i <= 10)
                        {
                            targetSeatsArr = boeingBusinessSeats;
                            columnSeat = 6;
                            adjustIdx = getAdjustIndexByClass(BUSINESS_ClASS) - 1;
                        }
                        else
                        {
                            targetSeatsArr = boeingEconomySeats;
                            columnSeat = 10;
                            adjustIdx = getAdjustIndexByClass(ECONOMY_ClASS) - 1;
                        }
                        break;

                    default:
                        return;
                }

                for (int j = 0; j < columnSeat; j++, buttonIdx++)
                {
                    if (string.Equals(targetSeatsArr[i - adjustIdx, j], AVAILABLE))
                    {
                        showStr = "E";
                    }
                    else
                    {
                        showStr = "R";
                    }

                    createButtonToTabPage(pCompanyName,
                                            buttonIdx,
                                            left + j * 20 + 30,
                                            top + i * 20,
                                            showStr,
                                            pCompanyName + "-" + pFloor.ToString() + "-" + (i + 1).ToString() + "-" + (j + 1).ToString());
                }
            }
        }

        private void createButtonToTabPage(string pCompany, int pButtonIdx, int pLeft, int pTop, string pText, string pName){
            //Button button = new Button();
            Button[] targetButtons;

            switch (pCompany)
            {
                case AIRBUS:
                    targetButtons = airbusButtons;
                    break;

                case BOEING:
                    if (pName.StartsWith(BOEING + "-1"))
                    {
                        targetButtons = boeingButtons;
                    }
                    else if (pName.StartsWith(BOEING + "-2"))
                    {
                        targetButtons = boeingButtons_SecondFloor;
                    }
                    else
                    {
                        return;
                    }

                 
                    break;

                default:
                    return;
            }

            targetButtons[pButtonIdx] = new Button();

            targetButtons[pButtonIdx].Left = pLeft;
            targetButtons[pButtonIdx].Top = pTop;
            targetButtons[pButtonIdx].Size = new Size(20, 20);
            targetButtons[pButtonIdx].Text = pText;
            targetButtons[pButtonIdx].Name = pName;    // format is [company]-[floor]-[row]-[column]

            targetButtons[pButtonIdx].Click += new System.EventHandler(ClickButton);

            if (string.Equals(pCompany, AIRBUS))
            {
                tabPage2.Controls.Add(targetButtons[pButtonIdx]);
            }
            else if (string.Equals(pCompany, BOEING))
            {
                if (pName.StartsWith(BOEING + "-1"))
                {
                    tabPage3.Controls.Add(targetButtons[pButtonIdx]);

                }
                else if (pName.StartsWith(BOEING + "-2"))
                {
                    tabPage4.Controls.Add(targetButtons[pButtonIdx]);
                
                }
            }

            // unexpected case
            else
            {
                return;
            }
                
        }

        private void createButtonToTabPage3(int pLeft, int pTop, string pText, string pName)
        {
            Button button = new Button();

            button.Left = pLeft;
            button.Top = pTop;
            button.Size = new Size(20, 20);
            button.Text = pText;
            button.Name = pName;

            button.Click += new System.EventHandler(ClickButton);


            tabPage3.Controls.Add(button);
        }

        public void ClickButton(Object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "E")
            {
                btn.Text = "R";
            }
            else if (btn.Text == "R")
            {
                btn.Text = "E";
            }

            //MessageBox.Show(btn.Name);
            string tmpName = btn.Name;
            char[] splitChar = { '-' };
            string[] tmpClickSeat = tmpName.Split(splitChar);

            string companyName = tmpClickSeat[0];
            string className; // its value depends on row.
            int floorNum = Convert.ToInt16(tmpClickSeat[1]);
            int rowNum = Convert.ToInt16(tmpClickSeat[2]);
            int columnNum = Convert.ToInt16(tmpClickSeat[3]);

            string[,] targetSeatsArr;

            switch (companyName)
            {
                case AIRBUS:
                    if (0 <= rowNum && rowNum <= 4)
                    {
                        targetSeatsArr = airbusFirstSeats;
                        className = FIRST_ClASS;
                    }

                    else if (5 <= rowNum && rowNum <= 10)
                    {
                        targetSeatsArr = airbusBusinessSeats;
                        className = BUSINESS_ClASS;
                    }

                    else if (11 <= rowNum && rowNum <= 34)
                    {
                        targetSeatsArr = airbusEconomySeats;
                        className = ECONOMY_ClASS;
                    }
                    else
                    {
                        return;
                    }
                    break;

                case BOEING:
                    if (0 <= rowNum && rowNum <= 4)
                    {
                        if (floorNum == 1)
                        {
                            targetSeatsArr = boeingFirstSeats_OneFloor;

                        }
                        else if (floorNum == 2)
                        {
                            targetSeatsArr = boeingFirstSeats_SecondFloor;
                        }
                        else
                        {
                            return;
                        }
                        
                        className = FIRST_ClASS;
                    }

                    else if (5 <= rowNum && rowNum <= 10)
                    {
                        targetSeatsArr = boeingBusinessSeats;
                        className = BUSINESS_ClASS;
                    }

                    else if (11 <= rowNum && rowNum <= 34)
                    {
                        targetSeatsArr = boeingEconomySeats;
                        className = ECONOMY_ClASS;
                    }
                    else
                    {
                        return;
                    }
                    break;

                default:
                    return;
            }

            //it worked.
            //MessageBox.Show(tmpClickSeat[0] + "/" + tmpClickSeat[1] + "/" + tmpClickSeat[2]);
            if (string.Equals(targetSeatsArr[rowNum - 1, columnNum - 1], AVAILABLE))
            {
                switch (companyName)
                {
                    case AIRBUS:
                        reserveAirplainSeat(className, rowNum, columnNum);
                        break;

                    case BOEING:
                        reserveAirplainSeat(className, floorNum, rowNum, columnNum);
                        break;

                    default:
                        return;
                }
            }
            else
            {
                switch (companyName)
                {
                    case AIRBUS:
                        cancelAirplainSeat(rowNum, columnNum);
                        break;

                    case BOEING:
                        cancelAirplainSeat(floorNum, rowNum, columnNum);
                        break;

                    default:
                        return;
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputAirPlane = comboBox1.Text;
            string inputClass = comboBox2.Text;
            int inputFloor = Convert.ToInt16(comboBox3.Text);
            int inputRow = Convert.ToInt16(textBox2.Text);
            int inputColumn = Convert.ToInt16(textBox3.Text);

            switch (inputAirPlane){

                case AIRBUS:
                    reserveAirplainSeat(inputClass, inputRow, inputColumn);
                    break;

                case BOEING:
                    reserveAirplainSeat(inputClass, inputFloor, inputRow, inputColumn);
                    break;

                default:
                    break;
            }
        }

        void reserveAirplainSeat(string pClass, int pRow, int pColumn)
        {
            string[,] targetSeatsArr;
            int adjustIdx = getAdjustIndexByClass(pClass);

            if (1 <= pRow && pRow <= 5)
            {
                targetSeatsArr = airbusFirstSeats;             
            }
            else if (6 <= pRow && pRow <= 11)
            {
                targetSeatsArr = airbusBusinessSeats;
            }
            else if (12 <= pRow && pRow <= 35)
            {
                targetSeatsArr = airbusEconomySeats;
            }

            //unexpected case
            else
            {
                return;
            }

            if (string.Equals(targetSeatsArr[pRow - adjustIdx, pColumn - 1], AVAILABLE))
            {
                targetSeatsArr[pRow - adjustIdx, pColumn - 1] = OCCUPID;
                MessageBox.Show("[Airbus] You got a seat successfully.");
            }
            else
            {
                MessageBox.Show("[Airbus] You didn't get a seat.");

            }
        }

        void reserveAirplainSeat(string pClass, int pFloor, int pRow, int pColumn)
        {
            string[,] targetSeatsArr;
            int adjustIdx = getAdjustIndexByClass(pClass);
            
            if(pFloor == 1){
                    if (1 <= pRow && pRow <= 5)
                    {
                        targetSeatsArr = boeingFirstSeats_OneFloor;

                    }
                    else if (6 <= pRow && pRow <= 11)
                    {
                        targetSeatsArr = boeingBusinessSeats;
                    }
                    else if (12 <= pRow && pRow <= 45)
                    {
                        targetSeatsArr = boeingEconomySeats;

                    }
                    else
                    {
                        return;
                    }

            }
            else if (pFloor == 2)
            {
                if (1 <= pRow && pRow <= 5)
                {
                    targetSeatsArr = boeingFirstSeats_SecondFloor;

                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }

            if (string.Equals(targetSeatsArr[pRow - adjustIdx, pColumn - 1], AVAILABLE))
            {
                targetSeatsArr[pRow - adjustIdx, pColumn - adjustIdx] = OCCUPID;
                MessageBox.Show("[Boeing] You got a seat successfully.");
            }
            else
            {
                MessageBox.Show("[Boeing] You didn't get a seat.");

            }
        }

        public int getAdjustIndexByClass(string pClass){

            int adjustIdx = 0;
            switch (pClass)
            {
                case FIRST_ClASS:
                    adjustIdx = 1;
                    break;

                case BUSINESS_ClASS:
                    adjustIdx = 6;
                    break;

                case ECONOMY_ClASS:
                    adjustIdx = 12;
                    break;
            }

            return adjustIdx;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string inputAirPlane = comboBox1.Text;
            int inputFloor = Convert.ToInt16(comboBox3.Text);
            int inputRow = Convert.ToInt16(textBox2.Text);
            int inputColumn = Convert.ToInt16(textBox3.Text);

            switch (inputAirPlane)
            {

                case "airbus":
                    cancelAirplainSeat(inputRow, inputColumn);
                    break;

                case "boeing":
                    cancelAirplainSeat(inputFloor, inputRow, inputColumn);
                    break;

                default:
                    break;
            }
        }

        void cancelAirplainSeat(int pRow, int pColumn)
        {
            string[,] targetSeatsArr;

            if (1 <= pRow && pRow <= 5)
            {
                targetSeatsArr = airbusFirstSeats;

            }
            else if (6 <= pRow && pRow <= 11)
            {
                targetSeatsArr = airbusBusinessSeats;
            }
            else if (12 <= pRow && pRow <= 35)
            {
                targetSeatsArr = airbusEconomySeats;
            }

            //unexpected case
            else
            {
                return;
            }

            if (string.Equals(targetSeatsArr[pRow - 1, pColumn - 1], OCCUPID))
            {
                targetSeatsArr[pRow - 1, pColumn - 1] = AVAILABLE;
                MessageBox.Show("[Airbus] You canceled a seat successfully.");
            }
            else
            {
                MessageBox.Show("[Airbus] No one get the seat.");

            }
        }

        void cancelAirplainSeat(int pFloor, int pRow, int pColumn)
        {
            string[,] targetSeatsArr;

            if (pFloor == 1)
            {
                if (1 <= pRow && pRow <= 5)
                {
                    targetSeatsArr = boeingFirstSeats_OneFloor;

                }
                else if (6 <= pRow && pRow <= 11)
                {
                    targetSeatsArr = boeingBusinessSeats;
                }
                else if (12 <= pRow && pRow <= 45)
                {
                    targetSeatsArr = boeingEconomySeats;

                }
                else
                {
                    return;
                }

            }
            else if (pFloor == 2)
            {
                if (1 <= pRow && pRow <= 5)
                {
                    targetSeatsArr = boeingFirstSeats_SecondFloor;

                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }


            if (string.Equals(targetSeatsArr[pRow - 1, pColumn - 1], OCCUPID))
            {
                targetSeatsArr[pRow - 1, pColumn - 1] = AVAILABLE;
                MessageBox.Show("[Boeing] You reserved successfully.");
            }
            else
            {
                MessageBox.Show("[Boeing] You didn't reserved a seat.");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string inputAirPlane = comboBox1.Text;
            string inputClass = comboBox2.Text;
            int inputFloor = Convert.ToInt16(comboBox3.Text);
            string[,] targetSeatsArr;

            switch (inputAirPlane)
            {
                case AIRBUS:
                    switch (inputClass)
                    {
                        case FIRST_ClASS:
                            targetSeatsArr = airbusFirstSeats;
                            break;

                        case BUSINESS_ClASS:
                            targetSeatsArr = airbusBusinessSeats;
                            break;

                        case ECONOMY_ClASS:
                            targetSeatsArr = airbusEconomySeats;
                            break;

                        default:
                            return;
                    }
                    break;

                case BOEING:
                    switch (inputClass)
                    {
                        case FIRST_ClASS:
                            if (inputFloor == 1)
                            {
                                targetSeatsArr = boeingFirstSeats_OneFloor;
                            }
                            else if (inputFloor == 2)
                            {
                                targetSeatsArr = boeingFirstSeats_SecondFloor;
                            }
                            else
                            {
                                return;
                            }
                            
                            break;

                        case BUSINESS_ClASS:
                            targetSeatsArr = boeingBusinessSeats;
                            break;

                        case ECONOMY_ClASS:
                            targetSeatsArr = boeingEconomySeats;
                            break;

                        default:
                            return;
                    }
                    break;

                default:
                    return;
            }

            richTextBox1.Text = "";
            int middleNum = (targetSeatsArr.GetLength(1) + 1) / 2;

            // airbus
            for (int i = 0; i < targetSeatsArr.GetLength(0); i++)
            {
                
                for (int j = 0; j < targetSeatsArr.GetLength(1); j++)
                {
                    // when reaching middle, input blank as aisle.
                    if (j == middleNum)
                    {
                        richTextBox1.Text += "   ";
                    }

                    if (string.Equals(targetSeatsArr[i, j], OCCUPID))
                    {
                        richTextBox1.Text += "R";
                    }
                    else if (string.Equals(targetSeatsArr[i, j], AVAILABLE))
                    {
                        richTextBox1.Text += "E";
                    }
                }

                richTextBox1.Text += Environment.NewLine;
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            int selectIdx = tabControl1.SelectedIndex;

            if (selectIdx == 1)
            {
                for (int i = 0; i < airbusButtons.Length; i++)
                {
                    airbusButtons[i].Dispose();
                    airbusButtons[i] = null;
                }

                createButtonsForAirline(AIRBUS, 1, 35);
            }

            if (selectIdx == 2)
            {
                for (int i = 0; i < boeingButtons.Length; i++)
                {
                    boeingButtons[i].Dispose();
                    boeingButtons[i] = null;
                }

                createButtonsForAirline(BOEING, 1, 45);
            }

            if (selectIdx == 3)
            {
                for (int i = 0; i < boeingButtons_SecondFloor.Length; i++)
                {
                    boeingButtons_SecondFloor[i].Dispose();
                    boeingButtons_SecondFloor[i] = null;
                }

                createButtonsForAirline(BOEING, 2, 5);                
            }
        }
    }
}
