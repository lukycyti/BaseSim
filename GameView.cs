using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseSim2021
{
    public partial class GameView : Form
    {

        private readonly WorldState theWorld;

        private Dictionary<IndexedValueView, String> IndexValueViews;
        private IndexedValueView Pointeur;
        /// <summary>
        /// The constructor for the main window
        /// </summary>
        public GameView(WorldState world)
        {
            InitializeComponent();
            theWorld = world;
            IndexValueViews = new Dictionary<IndexedValueView, String>();
            initializeView();
        }
            /// <summary>
            /// Method called by the controler whenever some text should be displayed
            /// </summary>
            /// <param name="s"></param>
            public void WriteLine(string s)
        {
            List<string> strs = s.Split('\n').ToList();
            strs.ForEach(str=>outputListBox.Items.Add(str));
            if (outputListBox.Items.Count > 0)
            {
                outputListBox.SelectedIndex = outputListBox.Items.Count - 1;
            }
            outputListBox.Refresh();
        }
        /// <summary>
        /// Method called by the controler whenever a confirmation should be asked
        /// </summary>
        /// <returns>Yes iff confirmed</returns>
        public bool ConfirmDialog()
        {
            string message = "Confirmer ?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            return MessageBox.Show(message, "", buttons) == DialogResult.Yes;
        }
        #region Event handling
        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                e.SuppressKeyPress = true; // Or beep.
                GameController.Interpret(inputTextBox.Text);
            }
        }

        private void initializeView()
        {
            Size size = new Size(180, 50);
            initializeIVV(theWorld.Policies, Color.Navy, size, new Point(290, 250), new Point(925, 500)); ;
            initializeIVV(theWorld.Perks, Color.DarkGreen, size, new Point(25, 20), new Point(400, 200));
            initializeIVV(theWorld.Indicators, Color.Gold, size, new Point(290, 25), new Point(925, 200));
            initializeIVV(theWorld.Crises, Color.DarkRed, size, new Point(975, 25), new Point(1200, 500));
            initializeIVV(theWorld.Groups, Color.Orange, size, new Point(975, 550), new Point(1200, 800));
        }


        private void initializeIVV(List<IndexedValue> iV, Color c, Size s, Point begin, Point end)
        {
            
            int x, y, marginX, marginY; marginX = 30; marginY = 20; x = begin.X; y = begin.Y;
            foreach (IndexedValue p in iV)
            {
                Point point = new Point(x, y);


                x += s.Width + marginX;
                if (x + s.Width >= end.X)
                {
                    x = begin.X; y += s.Height + marginY;
                }
                IndexedValueView IVV = new IndexedValueView(p, point, s, c);
                IndexValueViews.Add(IVV, iV.First().Type.ToString());
            }
            
        }

        private void GameView_Paint(object sender, PaintEventArgs e)
        {

            foreach (KeyValuePair<IndexedValueView, String > entry in IndexValueViews)
            {
                entry.Key.draw(e.Graphics);
            }

            if(Pointeur != null) {
                Rectangle r1 = Pointeur.getRectangle();
                e.Graphics.DrawRectangle(new Pen(Color.Gray, 2), r1);
                foreach (KeyValuePair<IndexedValue, Double> iV in Pointeur.getIndexedValue().OutputWeights)
                {
                    Color c;
                    int width = 3;
                    if(Math.Abs(iV.Value) < 1)
                    {
                        width = 2;
                        if(Math.Abs(iV.Value) < 0.1)
                        {
                            width = 1;
                        }
                    }
                    if(iV.Value < 0) { c = Color.Red; }
                    else { c = Color.Blue; }

                    Rectangle r = GetIndexedValueView(iV.Key).getRectangle();
                    e.Graphics.DrawRectangle(new Pen(c, width), r);
                    
                    
                }
            }


            diffLabel.Text = "Difficulté : " + theWorld.TheDifficulty;
            turnLabel.Text = "Tour " + theWorld.Turns;
            moneyLabel.Text = "Trésor : " + theWorld.Money;
            gloryLabel.Text = "Gloire :" + theWorld.Glory;
            nextButton.Visible = true;
        }

        #endregion
        public void EnableNextButton(bool b)
        {
            nextButton.Enabled = b;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            theWorld.NextTurn();
            foreach(IndexedValueView iVV in IndexValueViews.Keys)
            {
                iVV.CheckAvailable(theWorld.Turns);
            }
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GameController.Interpret("etat");
            GameController.Interpret("liste politiques");
            GameController.Interpret("liste taxes");

            GameController.Interpret("politique gardes 100");
            GameController.Interpret("politique pretres 100");
            GameController.Interpret("politique impots 40");

            GameController.Interpret("suivant");
            //GameController.Interpret("etat");
            //GameController.Interpret("liste");

            GameController.Interpret("politique subventions 100");
            GameController.Interpret("politique doleances 100");
            GameController.Interpret("politique quetegraal 10");

            GameController.Interpret("politique ecoles 100");
            GameController.Interpret("politique enchanteurs 100");
            GameController.Interpret("politique taxeluxe 10");

            GameController.Interpret("suivant");

            GameController.Interpret("politique theatres 100");
            GameController.Interpret("politique taxealcool 5");
            GameController.Interpret("politique agrandir territoires 2");
            GameController.Interpret("politique monstres 2");

            GameController.Interpret("suivant");
            GameController.Interpret("suivant");

            GameController.Interpret("politique thermes 100");
            GameController.Interpret("politique juges 100");
            GameController.Interpret("politique taxefonciere 5");
            GameController.Interpret("politique dragons 5");


            GameController.Interpret("suivant");
            GameController.Interpret("suivant");
            GameController.Interpret("suivant");
            GameController.Interpret("suivant");
            GameController.Interpret("suivant");
            GameController.Interpret("suivant");
            GameController.Interpret("suivant");
            GameController.Interpret("suivant");
            GameController.Interpret("suivant");
            GameController.Interpret("suivant");
            GameController.Interpret("suivant");
            GameController.Interpret("suivant");
            GameController.Interpret("suivant");
            GameController.Interpret("suivant");
            GameController.Interpret("suivant");
            GameController.Interpret("suivant");
            GameController.Interpret("suivant");
            GameController.Interpret("suivant");
            GameController.Interpret("suivant");
            GameController.Interpret("suivant");
            GameController.Interpret("suivant");
        }
        

        private IndexedValueView GetIndexedValueView(IndexedValue iV)
        {
            return IndexValueViews.Keys.FirstOrDefault(iVV => iV.Equals(iVV.getIndexedValue()));
        }

        private void GameView_MouseDown(object sender, MouseEventArgs e)
        {
            
            IndexedValueView iVV = Pointeur;
            if (iVV != null)
            {
                
                string type;
                IndexValueViews.TryGetValue(iVV, out type);
                if (!type.Equals("Policy"))
                {
                    
                    MessageBox.Show(iVV.getIndexedValue().Description);
                    return;
                }
                if (!(bool)iVV.getIndexedValue().Active && iVV.getIndexedValue().AvailableAt > theWorld.Turns) {
                    MessageBox.Show(iVV.getIndexedValue().Description + " (non disponible)");
                    return; 
                }
                // On clique sur une politique active
                Dialog dialP = new Dialog(iVV, true);
                if(dialP.ShowDialog() == DialogResult.OK) {
                    IndexedValue iV = dialP.iV;
                    int value = dialP.NewValue;
                    String arg = iV.Name + " " + value.ToString();
                    GameController.ApplyPolicyChanges(arg);
                }
                
            }
        }

        private IndexedValueView Selection(Point p)
        {
            return IndexValueViews.Keys.FirstOrDefault(c => c.getRectangle().Contains(p));
        }

        private void GameView_MouseMove(object sender, MouseEventArgs e)
        {
            Pointeur = Selection(e.Location);
            Refresh();
        }

        private void outputListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
