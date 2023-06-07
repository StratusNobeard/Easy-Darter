using System.Windows.Forms;

namespace Easy_Darter
{
    public partial class frm_easy_darter : Form
    {
        public frm_easy_darter()
        {
            InitializeComponent();
        }

        int numberOfPlayers = 0;

        int maxPoints = 0;

        int firstPlayerPoints = 0;
        int secondPlayerPoints = 0;
        int thirdPlayerPoints = 0;
        int fourthPlayerPoints = 0;

        private void btn_zapocni_igru_Click(object sender, EventArgs e)
        {
            numberOfPlayers = Convert.ToInt32(NUD_broj_igraca.Value);

            if (cmb_vrsta_igre.SelectedIndex == 1) maxPoints = 301;
            else maxPoints = 501;

            btn_zavrsi_igru.Enabled = true;

            cmb_vrsta_igre.Enabled = false;
            NUD_broj_igraca.Enabled = false;
            btn_zapocni_igru.Enabled = false;

            if (numberOfPlayers >= 2) {

                SetFirstPlayerState(true);
                SetSecondPlayerState(true);
                pb_bodovi_1.Maximum = maxPoints;
                pb_bodovi_2.Maximum = maxPoints;
            }
            if (numberOfPlayers >= 3)
            {
                SetThirdPlayerState(true);
                pb_bodovi_3.Maximum = maxPoints;
            }
            if (numberOfPlayers == 4)
            {
                fourthPlayer(true);
                pb_bodovi_4.Maximum = maxPoints;
            }


            pointRefresh();
        }

        private void btn_zavrsi_igru_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btn_bodovi_1_Click(object sender, EventArgs e)
        {
            if(NUD_bodovi_1.Value != 0)
            {
                lb_bodovi_1.Items.Add(NUD_bodovi_1.Value);
                NUD_bodovi_1.Value = 0;
            }

            pointRefresh();
        }

        private void btn_bodovi_2_Click(object sender, EventArgs e)
        {
            if (NUD_bodovi_2.Value != 0)
            {
                lb_bodovi_2.Items.Add(NUD_bodovi_2.Value);
                NUD_bodovi_2.Value = 0;
            }

            pointRefresh();
        }

        private void btn_bodovi_3_Click(object sender, EventArgs e)
        {
            if (NUD_bodovi_3.Value != 0)
            {
                lb_bodovi_3.Items.Add(NUD_bodovi_3.Value);
                NUD_bodovi_3.Value = 0;
            }

            pointRefresh();
        }

        private void btn_bodovi_4_Click(object sender, EventArgs e)
        {
            if (NUD_bodovi_4.Value != 0)
            {
                lb_bodovi_4.Items.Add(NUD_bodovi_4.Value);
                NUD_bodovi_4.Value = 0;
            }

            pointRefresh();
        }

        private void cmb_vrsta_igre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_vrsta_igre.SelectedIndex != -1)
            {
                btn_zapocni_igru.Enabled = true;
            } else
            {
                btn_zapocni_igru.Enabled = false;
            }
        }

        private void SetFirstPlayerState(bool state)
        {
            //prvi igrac
            lbl_igrac_1.Enabled = state;
            NUD_bodovi_1.Enabled = state;
            btn_bodovi_1.Enabled = state;
            lb_bodovi_1.Enabled = state;
            pb_bodovi_1.Enabled = state;
            lbl_bodovi_1.Enabled = state;
            lbl_preostali_bodovi_1.Visible = state;

            
        }

        private void SetSecondPlayerState(bool state)
        {
            //drugi igrac
            lbl_igrac_2.Enabled = state;
            NUD_bodovi_2.Enabled = state;
            btn_bodovi_2.Enabled = state;
            lb_bodovi_2.Enabled = state;
            pb_bodovi_2.Enabled = state;
            lbl_bodovi_2.Enabled = state;
            lbl_preostali_bodovi_2.Visible = state;
        }

        void SetThirdPlayerState(bool state)
        {

            //treci igrac
            lbl_igrac_3.Enabled = state;
            NUD_bodovi_3.Enabled = state;
            btn_bodovi_3.Enabled = state;
            lb_bodovi_3.Enabled = state;
            pb_bodovi_3.Enabled = state;
            lbl_bodovi_3.Enabled = state;
            lbl_preostali_bodovi_3.Visible = state;
        }

        void fourthPlayer(bool state)
        {
            //cetvrti igrac
            lbl_igrac_4.Enabled = state;
            NUD_bodovi_4.Enabled = state;
            btn_bodovi_4.Enabled = state;
            lb_bodovi_4.Enabled = state;
            pb_bodovi_4.Enabled = state;
            lbl_bodovi_4.Enabled = state;
            lbl_preostali_bodovi_4.Visible = state;
        }

        void Reset()
        {
            btn_zavrsi_igru.Enabled = false;
            btn_zapocni_igru.Enabled = false;

            numberOfPlayers = 0;
            maxPoints = 0;

            cmb_vrsta_igre.SelectedIndex = -1;
            NUD_broj_igraca.Value = 2;

            cmb_vrsta_igre.Enabled = true;
            NUD_broj_igraca.Enabled = true;

            firstPlayer(false);
            secondPlayer(false);
            thirdPlayer(false);
            fourthPlayer(false);

            pb_bodovi_1.Value = 0;
            pb_bodovi_2.Value = 0;
            pb_bodovi_3.Value = 0;
            pb_bodovi_4.Value = 0;

            lb_bodovi_1.Items.Clear();
            lb_bodovi_2.Items.Clear();
            lb_bodovi_3.Items.Clear();
            lb_bodovi_4.Items.Clear();


            pic_prvi_1.Visible = false;
            pic_prvi_2.Visible = false;
            pic_prvi_3.Visible = false;
            pic_prvi_4.Visible = false;
        }

        void pointRefresh()
        {
            firstPlayerPoints = 0;

            for (int i = 0; i < lb_bodovi_1.Items.Count; i++)
            {
                firstPlayerPoints += Convert.ToInt32(lb_bodovi_1.Items[i]);
            }
            if (firstPlayerPoints > maxPoints) firstPlayerPoints = maxPoints;
            lbl_preostali_bodovi_1.Text = (maxPoints - firstPlayerPoints).ToString();






            secondPlayerPoints = 0;

            for (int i = 0; i < lb_bodovi_2.Items.Count; i++)
            {
                secondPlayerPoints += Convert.ToInt32(lb_bodovi_2.Items[i]);
            }
            if (secondPlayerPoints > maxPoints) secondPlayerPoints = maxPoints;
            lbl_preostali_bodovi_2.Text = (maxPoints - secondPlayerPoints).ToString();






            thirdPlayerPoints = 0;

            for (int i = 0; i < lb_bodovi_3.Items.Count; i++)
            {
                thirdPlayerPoints += Convert.ToInt32(lb_bodovi_3.Items[i]);
            }
            if (thirdPlayerPoints > maxPoints) thirdPlayerPoints = maxPoints;
            lbl_preostali_bodovi_3.Text = (maxPoints - thirdPlayerPoints).ToString();
            





            fourthPlayerPoints = 0;

            for (int i = 0; i < lb_bodovi_4.Items.Count; i++)
            {
                fourthPlayerPoints += Convert.ToInt32(lb_bodovi_4.Items[i]);
            }
            if (fourthPlayerPoints > maxPoints) fourthPlayerPoints = maxPoints;
            lbl_preostali_bodovi_4.Text = (maxPoints - fourthPlayerPoints).ToString();


            if (numberOfPlayers >= 2)
            {
                pb_bodovi_1.Value = firstPlayerPoints;
                pb_bodovi_2.Value = secondPlayerPoints;
            }
            if (numberOfPlayers >= 3)
            {
                pb_bodovi_3.Value = thirdPlayerPoints;
            }
            if (numberOfPlayers == 4)
            {
                pb_bodovi_4.Value = fourthPlayerPoints;
            }


            if((maxPoints - firstPlayerPoints) <= 0)
            {
                MessageBox.Show("Prvi igrac je pobijedio!");
                Reset();
            }
            else if ((maxPoints - secondPlayerPoints) <= 0)
            {
                MessageBox.Show("Drugi igrac je pobijedio!");
                Reset();
            }
            else if ((maxPoints - thirdPlayerPoints) <= 0)
            {
                MessageBox.Show("Treci igrac je pobijedio!");
                Reset();
            }
            else if ((maxPoints - fourthPlayerPoints) <= 0)
            {
                MessageBox.Show("Cetvrti igrac je pobijedio!");
                Reset();
            }

            int max = 0;

            if(firstPlayerPoints > max)
            {
                max = firstPlayerPoints;

                pic_prvi_1.Visible = true;

                pic_prvi_2.Visible = false;
                pic_prvi_3.Visible = false;
                pic_prvi_4.Visible = false;
            }

            if (secondPlayerPoints > max)
            {
                max = secondPlayerPoints;

                pic_prvi_2.Visible = true;

                pic_prvi_1.Visible = false;
                pic_prvi_3.Visible = false;
                pic_prvi_4.Visible = false;
            }

            if (thirdPlayerPoints > max)
            {
                max = thirdPlayerPoints;

                pic_prvi_3.Visible = true;

                pic_prvi_2.Visible = false;
                pic_prvi_1.Visible = false;
                pic_prvi_4.Visible = false;
            }

            if (fourthPlayerPoints > max)
            {
                max = fourthPlayerPoints;

                pic_prvi_4.Visible = true;

                pic_prvi_2.Visible = false;
                pic_prvi_3.Visible = false;
                pic_prvi_1.Visible = false;
            }
        }
    }
}