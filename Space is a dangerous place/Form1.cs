using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Space_is_a_dangerous_place.Properties;
using System.Reflection;
using System.IO;
using System.Resources;

namespace Space_is_a_dangerous_place //polish bei world gen (+ code kürzen)
{
    public partial class Form1 : Form
    {
        int raumschiffposix = 300, raumschiffxbewegung = 0, raumschiffyposi = 500;


        int recklinksxposi = 0, recklinksyposi = -10, recklinksxgröße = 200, recklinksygröße = 200;
        int reckrechtsxposi = 438, reckrechtsyposi = -10, reckrechtsxgröße = 200, reckrechtsygröße = 200;

        int recklinksxposi1 = 0, recklinksyposi1 = 0, recklinksxgröße1 = 0, recklinksygröße1 = 0;
        int reckrechtsxposi1 = 0, reckrechtsyposi1 = 0, reckrechtsxgröße1 = 0, reckrechtsygröße1 = 0;

        int recklinksxposi2 = 0, recklinksyposi2 = 0, recklinksxgröße2 = 0, recklinksygröße2 = -200;
        int reckrechtsxposi2 = 0, reckrechtsyposi2 = 0, reckrechtsxgröße2 = 0, reckrechtsygröße2 = -200;

        int recklinksxposi3 = 0, recklinksyposi3 = 0, recklinksxgröße3 = 0, recklinksygröße3 = -200;
        int reckrechtsxposi3 = 0, reckrechtsyposi3 = 0, reckrechtsxgröße3 = 0, reckrechtsygröße3 = -200;

        int schussposiy, schussposix, schuss2posix, schuss2posiy, schuss3posix, schuss3posiy, schuss4posiy, schuss4posix;

        int zufallszahlspawn, munitionyposi, munitionxposi, scoreyposi, scorexposi;

        int alienxposi, alienyposi;

        int alienlootscorexposi, alienlootscoreyposi, alienlootmunixposi, alienlootmuniyposi, alienlootbombexposi, alienlootbombeyposi;

        int zufalll, zufallr;


        int counterlinks = 0, counterrechts = 0;
        int zufallsxgröße, zufallsygröße;
        bool warnunglinks = false, warnungrechts = false, schussunterwegs = false, munitionauffeld = false, scoreauffeld = false, schuss2auffeld = false, schuss3auffeld = false, alienauffeld = false, aliennachlinks = true, alienlootscoreauffeld = false, alienlootmuniauffeld = false, alienlootbombeauffeld = false;

        bool score25 = false, score50 = false, score75 = false, schuss4unterwegs = false, endeschonerlebt = false, endeläuft = false;

        int score = 0, munition = 10;

        int timercounter = 0, messagecounter = 100, steuerungscounter = 0, endecounter = 0;

        int hs = Properties.Settings.Default.highscore;

        Image raumschiffbild = Resources.raumschiffbild;
        Image munitionsbild = Resources.munitionsbild;
        Image scorebild = Resources.scorebild;
        Image geländebild = Resources.geländebild3;
        Image almunibild = Resources.alienlootmunition;
        Image alscorebild = Resources.alienlootscore;
        Image albombebild = Resources.alienlootbombe;
        Image geländezerstörtbildl = Resources.geländezerstörtbildlinks;
        Image geländezerstörtbildr = Resources.geländezerstörtbildrechts;

        Image alienbild = Resources.alienbildt;
        //Bitmap alienbild = new Bitmap(@"C:\Users\Henry Wersing\Documents\Visual Studio 2015\Projects\Space is a dangerous place\alienbildt.png");

        
        Rectangle rechteckschuss = new Rectangle(-20, 0, 5, 15);
        Rectangle rechteckschuss2 = new Rectangle(-20, 0, 5, 15);
        Rectangle rechteckschuss3 = new Rectangle(-20, 0, 5, 15);
        Rectangle rechteckschuss4 = new Rectangle(-20, 0, 5, 15);


        SolidBrush brushschuss = new SolidBrush(Color.Crimson);

        Random rdm = new Random();
        

        public Form1()
        {
            InitializeComponent();

            zufalll = rdm.Next(130, 250);

            labeltutorial.Text = "Links /Rechts - bewegen\nRunter - Schießen\n\nMu steht für Munition\nSc steht für den Score.\n\nSammle möglichst viel Score, ohne\nin die Hindernisse zu fliegen.\n\nHighscore: " + hs;

            raumschiffbild = new Bitmap(raumschiffbild, 35, 70);
            labelraumschiff.Size = new Size(35, 70);
            labelraumschiff.Image = raumschiffbild;

            munitionsbild = new Bitmap(munitionsbild, 25, 25);
            labelmunition.Size = new Size(25, 25);
            labelmunition.Image = munitionsbild;

            scorebild = new Bitmap(scorebild, 25, 25);
            labelscore.Size = new Size(25, 25);
            labelscore.Image = scorebild;

            geländebild = new Bitmap(geländebild, 390, 300);

            labelrecklinks.Size = new Size(200, 200);
            labelrecklinks.Image = geländebild;
            
            labelrecklinks1.Size = new Size(0, 0);
            labelrecklinks1.Image = geländebild;
            
            labelrecklinks2.Size = new Size(0, 0);
            labelrecklinks2.Image = geländebild;
            
            labelrecklinks3.Size = new Size(0, 0);
            labelrecklinks3.Image = geländebild;
            
            labelreckrechts.Size = new Size(200, 200);
            labelreckrechts.Image = geländebild;
            
            labelreckrechts1.Size = new Size(0, 0);
            labelreckrechts1.Image = geländebild;
            
            labelreckrechts2.Size = new Size(0, 0);
            labelreckrechts2.Image = geländebild;
            
            labelreckrechts3.Size = new Size(0, 0);
            labelreckrechts3.Image = geländebild;

            alscorebild = new Bitmap(alscorebild, 50, 35);
            labelalienlootscore.Size = new Size(50, 35);
            labelalienlootscore.Image = alscorebild;

            almunibild = new Bitmap(almunibild, 50, 35);
            labelalienlootmuni.Size = new Size(50, 35);
            labelalienlootmuni.Image = almunibild;

            albombebild = new Bitmap(albombebild, 50, 35);
            labelalienlootbombe.Size = new Size(50, 35);
            labelalienlootbombe.Image = albombebild;


            alienbild = new Bitmap(alienbild, 50, 35);
            //Color backColor = alienbild.GetPixel(0, 0);
            //alienbild.MakeTransparent(backColor);
            labelalien.Size = new Size(50, 35);
            labelalien.Image = alienbild;

            labelmessage.Location = new Point(700, 0);

            KeyPreview = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics meingraphicobject = this.CreateGraphics();
            meingraphicobject.FillRectangle(brushschuss, rechteckschuss);
            meingraphicobject.FillRectangle(brushschuss, rechteckschuss2);
            meingraphicobject.FillRectangle(brushschuss, rechteckschuss3);
            meingraphicobject.FillRectangle(brushschuss, rechteckschuss4);
        }

    private void timer1_Tick(object sender, EventArgs e)
        {
            messagecounter++;
            if(messagecounter==70)
            {
                labelmessage.Location = new Point(700, 0);
            }

            if (score >= 25 && score25 == false)
            {
                score25 = true;
                ShowMessage("25 Score!", 260);
            }
            if (score >= 50 && score50 == false)
            {
                score50 = true;
                ShowMessage("50 Score!", 260);
            }
            if (score >= 75 && score75 == false)
            {
                score75 = true;
                ShowMessage("75 Score!", 260);
            }

            //geländeprogrammierung

            

            if (recklinksyposi > 647) { recklinksxposi = 0; recklinksyposi = -1000; recklinksxgröße = 0; recklinksygröße = 0; }
            if (reckrechtsyposi > 647) { reckrechtsxposi = 0; reckrechtsyposi = -1000; reckrechtsxgröße = 0; reckrechtsygröße = 0; }
            if (recklinksyposi1 > 647) { recklinksxposi1 = 0; recklinksyposi1 = -1000; recklinksxgröße1 = 0; recklinksygröße1 = 0; }
            if (reckrechtsyposi1 > 647) { reckrechtsxposi1 = 0; reckrechtsyposi1 = -1000; reckrechtsxgröße1 = 0; reckrechtsygröße1 = 0; }
            if (recklinksyposi2 > 647) { recklinksxposi2 = 0; recklinksyposi2 = -1000; recklinksxgröße2 = 0; recklinksygröße2 = 0; }
            if (reckrechtsyposi2 > 647) { reckrechtsxposi2 = 0; reckrechtsyposi2 = -1000; reckrechtsxgröße2 = 0; reckrechtsygröße2 = 0; }
            if (recklinksyposi3 > 647) { recklinksxposi3 = 0; recklinksyposi3 = -1000; recklinksxgröße3 = 0; recklinksygröße3 = 0; }
            if (reckrechtsyposi3 > 647) { reckrechtsxposi3 = 0; reckrechtsyposi3 = -1000; reckrechtsxgröße3 = 0; reckrechtsygröße3 = 0; }

            if (((recklinksyposi > -3 && recklinksyposi < 0) || (recklinksyposi1 > -3 && recklinksyposi1 < 0) || (recklinksyposi2 > -3 && recklinksyposi2 < 0) || (recklinksyposi3 > -3 && recklinksyposi3 < 0))&&endeläuft==false)
            {

                counterlinks++;
                if (counterlinks >= 4) { counterlinks = 0; }


                if (counterlinks == 1)
                {
                    labelrecklinks1.Image = geländebild;

                    if (warnungrechts == false)
                    {
                        zufallsxgröße = rdm.Next(200, 390);
                    }
                    else
                    {
                        zufallsxgröße = rdm.Next(150, 250);
                    }
                    if (zufallsxgröße > recklinksxgröße - 20 && zufallsxgröße < recklinksxgröße + 20) { zufallsxgröße = recklinksxgröße; }
                    if (zufallsxgröße>250) { warnunglinks = true; }
                    else { warnunglinks = false; }

                    zufallsygröße = rdm.Next(220, 300);

                    recklinksxgröße1 = zufallsxgröße;
                    recklinksygröße1 = zufallsygröße;
                    recklinksyposi1 = recklinksyposi - recklinksygröße1;
                    recklinksxposi1 = 0;

                    zufallszahlspawn = rdm.Next(1, 7);
                    
                    if(munitionauffeld==false&&zufallszahlspawn==1)
                    {
                        munitionauffeld = true;
                        labelmunition.Location = new Point(recklinksxgröße1 + 5, recklinksyposi1 + (recklinksygröße1 / 2));
                        munitionyposi = recklinksyposi1 + recklinksygröße1 / 2;
                        munitionxposi = recklinksxgröße1 + 5;
                    }
                    if(scoreauffeld==false&&(zufallszahlspawn==2||zufallszahlspawn==3||zufallszahlspawn==4))
                    {
                        scoreauffeld = true;
                        labelscore.Location = new Point(recklinksxgröße1 + 5, recklinksyposi1 + (recklinksygröße1 / 2));
                        scoreyposi = recklinksyposi1 + recklinksygröße1 / 2;
                        scorexposi = recklinksxgröße1 + 5;
                    }
                    
                }
                if (counterlinks == 2)
                {
                    labelrecklinks2.Image = geländebild;

                    if (warnungrechts == false)
                    {
                        zufallsxgröße = rdm.Next(200, 390);
                    }
                    else
                    {
                        zufallsxgröße = rdm.Next(150, 250);
                    }
                    if (zufallsxgröße > recklinksxgröße1 - 20 && zufallsxgröße < recklinksxgröße1 + 20) { zufallsxgröße = recklinksxgröße1; }
                    if (zufallsxgröße > 250) { warnunglinks = true; }
                    else { warnunglinks = false; }

                    zufallsygröße = rdm.Next(220, 300);

                    recklinksxgröße2 = zufallsxgröße;
                    recklinksygröße2 = zufallsygröße;
                    recklinksyposi2 = recklinksyposi1 - recklinksygröße2;
                    recklinksxposi2 = 0;

                    zufallszahlspawn = rdm.Next(1, 7);

                    if (munitionauffeld == false && zufallszahlspawn == 1)
                    {
                        munitionauffeld = true;
                        labelmunition.Location = new Point(recklinksxgröße2 + 5, recklinksyposi2 + (recklinksygröße2 / 2));
                        munitionyposi = recklinksyposi2 + recklinksygröße2 / 2;
                        munitionxposi = recklinksxgröße2 + 5;
                    }
                    if (scoreauffeld == false && (zufallszahlspawn == 2 || zufallszahlspawn == 3 || zufallszahlspawn == 4))
                    {
                        scoreauffeld = true;
                        labelscore.Location = new Point(recklinksxgröße2 + 5, recklinksyposi2 + (recklinksygröße2 / 2));
                        scoreyposi = recklinksyposi2 + recklinksygröße2 / 2;
                        scorexposi = recklinksxgröße2 + 5;
                    }

                }
                if (counterlinks == 3)
                {
                    labelrecklinks3.Image = geländebild;

                    if (warnungrechts == false)
                    {
                        zufallsxgröße = rdm.Next(200, 390);
                    }
                    else
                    {
                        zufallsxgröße = rdm.Next(150, 250);
                    }
                    if (zufallsxgröße > recklinksxgröße2 - 20 && zufallsxgröße < recklinksxgröße2 + 20) { zufallsxgröße = recklinksxgröße2; }
                    if (zufallsxgröße > 250) { warnunglinks = true; }
                    else { warnunglinks = false; }

                    zufallsygröße = rdm.Next(220, 300);

                    recklinksxgröße3 = zufallsxgröße;
                    recklinksygröße3 = zufallsygröße;
                    recklinksyposi3 = recklinksyposi2 - recklinksygröße3;
                    recklinksxposi3 = 0;

                    zufallszahlspawn = rdm.Next(1, 7);

                    if (munitionauffeld == false && zufallszahlspawn == 1)
                    {
                        munitionauffeld = true;
                        labelmunition.Location = new Point(recklinksxgröße3 + 5, recklinksyposi3 + (recklinksygröße3 / 2));
                        munitionyposi = recklinksyposi3 + recklinksygröße3 / 2;
                        munitionxposi = recklinksxgröße3 + 5;
                    }
                    if (scoreauffeld == false && (zufallszahlspawn == 2 || zufallszahlspawn == 3 || zufallszahlspawn == 4))
                    {
                        scoreauffeld = true;
                        labelscore.Location = new Point(recklinksxgröße3 + 5, recklinksyposi3 + (recklinksygröße3 / 2));
                        scoreyposi = recklinksyposi3 + recklinksygröße3 / 2;
                        scorexposi = recklinksxgröße3 + 5;
                    }
                    

                }
                if (counterlinks == 0)
                {
                    labelrecklinks.Image = geländebild;

                    if (warnungrechts == false)
                    {
                        zufallsxgröße = rdm.Next(200, 390);
                    }
                    else
                    {
                        zufallsxgröße = rdm.Next(150, 300);
                    }
                    if (zufallsxgröße > recklinksxgröße3 - 20 && zufallsxgröße < recklinksxgröße3 + 20) { zufallsxgröße = recklinksxgröße3; }
                    if (zufallsxgröße > 250) { warnunglinks = true; }
                    else { warnunglinks = false; }

                    zufallsygröße = rdm.Next(220, 250);

                    recklinksxgröße = zufallsxgröße;
                    recklinksygröße = zufallsygröße;
                    recklinksyposi = recklinksyposi3 - recklinksygröße;
                    recklinksxposi = 0;

                    zufallszahlspawn = rdm.Next(1, 7);

                    if (munitionauffeld == false && zufallszahlspawn == 1)
                    {
                        munitionauffeld = true;
                        labelmunition.Location = new Point(recklinksxgröße + 5, recklinksyposi + (recklinksygröße / 2));
                        munitionyposi = recklinksyposi + recklinksygröße / 2;
                        munitionxposi = recklinksxgröße + 5;
                    }
                    if (scoreauffeld == false && (zufallszahlspawn == 2 || zufallszahlspawn == 3 || zufallszahlspawn == 4))
                    {
                        scoreauffeld = true;
                        labelscore.Location = new Point(recklinksxgröße + 5, recklinksyposi + (recklinksygröße / 2));
                        scoreyposi = recklinksyposi + recklinksygröße / 2;
                        scorexposi = recklinksxgröße + 5;
                    }

                }


            }

            if (((reckrechtsyposi > -3 && reckrechtsyposi < 0) || (reckrechtsyposi1 > -3 && reckrechtsyposi1 < 0) || (reckrechtsyposi2 > -3 && reckrechtsyposi2 < 0) || (reckrechtsyposi3 > -3 && reckrechtsyposi3 < 0)) && endeläuft == false)
            {

                counterrechts++;
                if (counterrechts >= 4) { counterrechts = 0; }


                if (counterrechts == 1)
                {
                    labelreckrechts1.Image = geländebild;

                    if (warnunglinks == false)
                    {
                        zufallsxgröße = rdm.Next(200, 390);
                    }
                    else
                    {
                        zufallsxgröße = rdm.Next(150, 250);
                    }
                    if (zufallsxgröße < reckrechtsxgröße + 20 && zufallsxgröße > reckrechtsxgröße - 20) { zufallsxgröße = reckrechtsxgröße; }
                    if (zufallsxgröße > 250) { warnungrechts = true; }
                    else { warnungrechts = false; }

                    zufallsygröße = rdm.Next(220, 300);

                    reckrechtsxgröße1 = zufallsxgröße;
                    reckrechtsygröße1 = zufallsygröße;
                    reckrechtsyposi1 = reckrechtsyposi - reckrechtsygröße1;
                    reckrechtsxposi1 = 638 - reckrechtsxgröße1;

                    zufallszahlspawn = rdm.Next(1, 7);

                    if (munitionauffeld == false && zufallszahlspawn == 1)
                    {
                        munitionauffeld = true;
                        labelmunition.Location = new Point(reckrechtsxposi1 - 30, reckrechtsyposi1 + (reckrechtsygröße1 / 2));
                        munitionyposi = reckrechtsyposi1 + reckrechtsygröße1 / 2;
                        munitionxposi = reckrechtsxposi1 - 30;
                    }
                    if (scoreauffeld == false && (zufallszahlspawn == 2 || zufallszahlspawn == 3 || zufallszahlspawn == 4))
                    {
                        scoreauffeld = true;
                        labelscore.Location = new Point(reckrechtsxposi1 - 30, reckrechtsyposi1 + (reckrechtsygröße1 / 2));
                        scoreyposi = reckrechtsyposi1 + reckrechtsygröße1 / 2;
                        scorexposi = reckrechtsxposi1 - 30;
                    }

                }
                if (counterrechts == 2)
                {
                    labelreckrechts2.Image = geländebild;

                    if (warnunglinks == false)
                    {
                        zufallsxgröße = rdm.Next(200, 390);
                    }
                    else
                    {
                        zufallsxgröße = rdm.Next(150, 250);
                    }
                    if (zufallsxgröße < reckrechtsxgröße1 + 20 && zufallsxgröße > reckrechtsxgröße1 - 20) { zufallsxgröße = reckrechtsxgröße1; }
                    if (zufallsxgröße > 250) { warnungrechts = true; }
                    else { warnungrechts = false; }

                    zufallsygröße = rdm.Next(220, 300);

                    reckrechtsxgröße2 = zufallsxgröße;
                    reckrechtsygröße2 = zufallsygröße;
                    reckrechtsyposi2 = reckrechtsyposi1 - reckrechtsygröße2;
                    reckrechtsxposi2 = 638 - reckrechtsxgröße2;

                    zufallszahlspawn = rdm.Next(1, 7);

                    if (munitionauffeld == false && zufallszahlspawn == 1)
                    {
                        munitionauffeld = true;
                        labelmunition.Location = new Point(reckrechtsxposi2 - 30, reckrechtsyposi2 + (reckrechtsygröße2 / 2));
                        munitionyposi = reckrechtsyposi2 + reckrechtsygröße2 / 2;
                        munitionxposi = reckrechtsxposi2 - 30;
                    }
                    if (scoreauffeld == false && (zufallszahlspawn == 2 || zufallszahlspawn == 3 || zufallszahlspawn == 4))
                    {
                        scoreauffeld = true;
                        labelscore.Location = new Point(reckrechtsxposi2 - 30, reckrechtsyposi2 + (reckrechtsygröße2 / 2));
                        scoreyposi = reckrechtsyposi2 + reckrechtsygröße2 / 2;
                        scorexposi = reckrechtsxposi2 - 30;
                    }

                }
                if (counterrechts == 3)
                {
                    labelreckrechts3.Image = geländebild;

                    if (warnunglinks == false)
                    {
                        zufallsxgröße = rdm.Next(200, 390);
                    }
                    else
                    {
                        zufallsxgröße = rdm.Next(150, 250);
                    }
                    if (zufallsxgröße < reckrechtsxgröße2 + 20 && zufallsxgröße > reckrechtsxgröße2 - 20) { zufallsxgröße = reckrechtsxgröße2; }
                    if (zufallsxgröße > 250) { warnungrechts = true; }
                    else { warnungrechts = false; }

                    zufallsygröße = rdm.Next(220, 300);

                    reckrechtsxgröße3 = zufallsxgröße;
                    reckrechtsygröße3 = zufallsygröße;
                    reckrechtsyposi3 = reckrechtsyposi2 - reckrechtsygröße3;
                    reckrechtsxposi3 = 638 - reckrechtsxgröße3;

                    zufallszahlspawn = rdm.Next(1, 7);

                    if (munitionauffeld == false && zufallszahlspawn == 1)
                    {
                        munitionauffeld = true;
                        labelmunition.Location = new Point(reckrechtsxposi3 - 30, reckrechtsyposi3 + (reckrechtsygröße3 / 2));
                        munitionyposi = reckrechtsyposi3 + reckrechtsygröße3 / 2;
                        munitionxposi = reckrechtsxposi3 - 30;
                    }
                    if (scoreauffeld == false && (zufallszahlspawn == 2 || zufallszahlspawn == 3 || zufallszahlspawn == 4))
                    {
                        scoreauffeld = true;
                        labelscore.Location = new Point(reckrechtsxposi3 - 30, reckrechtsyposi3 + (reckrechtsygröße3 / 2));
                        scoreyposi = reckrechtsyposi3 + reckrechtsygröße3 / 2;
                        scorexposi = reckrechtsxposi3 - 30;
                    }

                }
                if (counterrechts == 0)
                {
                    labelreckrechts.Image = geländebild;

                    if (warnunglinks == false)
                    {
                        zufallsxgröße = rdm.Next(200, 390);
                    }
                    else
                    {
                        zufallsxgröße = rdm.Next(150, 250);
                    }
                    if (zufallsxgröße < reckrechtsxgröße3 + 20 && zufallsxgröße > reckrechtsxgröße3 - 20) { zufallsxgröße = reckrechtsxgröße3; }
                    if (zufallsxgröße > 250) { warnungrechts = true; }
                    else { warnungrechts = false; }

                    zufallsygröße = rdm.Next(220, 300);

                    reckrechtsxgröße = zufallsxgröße;
                    reckrechtsygröße = zufallsygröße;
                    reckrechtsyposi = reckrechtsyposi3 - reckrechtsygröße;
                    reckrechtsxposi = 638 - reckrechtsxgröße;

                    zufallszahlspawn = rdm.Next(1, 7);

                    if (munitionauffeld == false && zufallszahlspawn == 1)
                    {
                        munitionauffeld = true;
                        labelmunition.Location = new Point(reckrechtsxposi - 30, reckrechtsyposi + (reckrechtsygröße / 2));
                        munitionyposi = reckrechtsyposi + reckrechtsygröße / 2;
                        munitionxposi = reckrechtsxposi - 30;
                    }
                    if (scoreauffeld == false && (zufallszahlspawn == 2 || zufallszahlspawn == 3 || zufallszahlspawn == 4))
                    {
                        scoreauffeld = true;
                        labelscore.Location = new Point(reckrechtsxposi - 30, reckrechtsyposi + (reckrechtsygröße / 2));
                        scoreyposi = reckrechtsyposi + reckrechtsygröße / 2;
                        scorexposi = reckrechtsxposi - 30;
                    }

                }

            }


            labelrecklinks.Location = new Point(recklinksxposi, recklinksyposi);
            labelreckrechts.Location = new Point(reckrechtsxposi, reckrechtsyposi);
            labelrecklinks.Size = new Size(recklinksxgröße, recklinksygröße);
            labelreckrechts.Size = new Size(reckrechtsxgröße, reckrechtsygröße);

            labelrecklinks1.Location = new Point(recklinksxposi1, recklinksyposi1);
            labelreckrechts1.Location = new Point(reckrechtsxposi1, reckrechtsyposi1);
            labelrecklinks1.Size = new Size(recklinksxgröße1, recklinksygröße1);
            labelreckrechts1.Size = new Size(reckrechtsxgröße1, reckrechtsygröße1);

            labelrecklinks2.Location = new Point(recklinksxposi2, recklinksyposi2);
            labelreckrechts2.Location = new Point(reckrechtsxposi2, reckrechtsyposi2);
            labelrecklinks2.Size = new Size(recklinksxgröße2, recklinksygröße2);
            labelreckrechts2.Size = new Size(reckrechtsxgröße2, reckrechtsygröße2);

            labelrecklinks3.Location = new Point(recklinksxposi3, recklinksyposi3);
            labelreckrechts3.Location = new Point(reckrechtsxposi3, reckrechtsyposi3);
            labelrecklinks3.Size = new Size(recklinksxgröße3, recklinksygröße3);
            labelreckrechts3.Size = new Size(reckrechtsxgröße3, reckrechtsygröße3);


            recklinksyposi += 2;
            reckrechtsyposi += 2;
            recklinksyposi1 += 2;
            reckrechtsyposi1 += 2;
            recklinksyposi2 += 2;
            reckrechtsyposi2 += 2;
            recklinksyposi3 += 2;
            reckrechtsyposi3 += 2;

            if ((recklinksyposi + recklinksygröße > 500 && recklinksyposi < 570 && raumschiffposix < (recklinksxposi + recklinksxgröße)) && endeläuft == false) { geländetimer.Stop(); raumschifftimer.Stop(); ShowMessage("Crash!", 273); HighscoreSpeichern(); }
            if ((reckrechtsyposi + reckrechtsygröße > 500 && reckrechtsyposi < 570 && raumschiffposix + 35 > reckrechtsxposi) && endeläuft == false) { geländetimer.Stop(); raumschifftimer.Stop(); ShowMessage("Crash!", 273); HighscoreSpeichern(); }
            if ((recklinksyposi1 + recklinksygröße1 > 500 && recklinksyposi1 < 570 && raumschiffposix < (recklinksxposi1 + recklinksxgröße1)) && endeläuft == false) { geländetimer.Stop(); raumschifftimer.Stop(); ShowMessage("Crash!", 273); HighscoreSpeichern(); }
            if ((reckrechtsyposi1 + reckrechtsygröße1 > 500 && reckrechtsyposi1 < 570 && raumschiffposix + 35 > reckrechtsxposi1) && endeläuft == false) { geländetimer.Stop(); raumschifftimer.Stop(); ShowMessage("Crash!", 273); HighscoreSpeichern(); }
            if ((recklinksyposi2 + recklinksygröße2 > 500 && recklinksyposi2 < 570 && raumschiffposix < (recklinksxposi2 + recklinksxgröße2)) && endeläuft == false) { geländetimer.Stop(); raumschifftimer.Stop(); ShowMessage("Crash!", 273); HighscoreSpeichern(); }
            if ((reckrechtsyposi2 + reckrechtsygröße2 > 500 && reckrechtsyposi2 < 570 && raumschiffposix + 35 > reckrechtsxposi2) && endeläuft == false) { geländetimer.Stop(); raumschifftimer.Stop(); ShowMessage("Crash!", 273); HighscoreSpeichern(); }
            if ((recklinksyposi3 + recklinksygröße3 > 500 && recklinksyposi3 < 570 && raumschiffposix < (recklinksxposi3 + recklinksxgröße3)) && endeläuft == false) { geländetimer.Stop(); raumschifftimer.Stop(); ShowMessage("Crash!", 273); HighscoreSpeichern(); }
            if ((reckrechtsyposi3 + reckrechtsygröße3 > 500 && reckrechtsyposi3 < 570 && raumschiffposix + 35 > reckrechtsxposi3) && endeläuft == false) { geländetimer.Stop(); raumschifftimer.Stop(); ShowMessage("Crash!", 273); HighscoreSpeichern(); }


            if (munitionauffeld == true)
            {
                munitionyposi += 2;
                labelmunition.Location = new Point(munitionxposi, munitionyposi);
                if (munitionyposi + 25 > 500 && munitionyposi < 570 && munitionxposi + 25 > raumschiffposix && munitionxposi < raumschiffposix + 35)
                {
                    munition++;
                    labelmunition.Location = new Point(-100, 0);
                    munitionauffeld = false;
                    munitionxposi = 0;
                    munitionyposi = 0;
                }
            }

            if (scoreauffeld == true)
            {
                scoreyposi += 2;
                labelscore.Location = new Point(scorexposi, scoreyposi);
                if (scoreyposi + 25 > 500 && scoreyposi < 570 && scorexposi + 25 > raumschiffposix && scorexposi < raumschiffposix + 35)
                {
                    score++;
                    scorexposi = 0;
                    scoreyposi = 0;
                    labelscore.Location = new Point(-100, 0);
                    scoreauffeld = false;
                }
            }

            
            if (alienauffeld == false && endeläuft == false)
            {
                int zufall = rdm.Next(1, 801);
                if (zufall == 1)
                {
                    alienauffeld = true;
                    labelalien.Location = new Point(294, -50);
                    alienxposi = 294;
                    alienyposi = -50;
                }
            }
            
            if (alienauffeld == true)
            {
                if (aliennachlinks == true)
                {
                    alienyposi += 1;
                    alienxposi -= 1;
                    labelalien.Location = new Point(alienxposi, alienyposi);
                    if (alienxposi < zufalll)
                    {
                        aliennachlinks = false;
                        zufalll = rdm.Next(160, 250);
                        zufallr = rdm.Next(388, 478);
                    }
                }

                else if (aliennachlinks == false)
                {
                    alienyposi += 1;
                    alienxposi += 1;
                    labelalien.Location = new Point(alienxposi, alienyposi);
                    if (alienxposi > zufallr)
                    {
                        aliennachlinks = true;
                        zufalll = rdm.Next(160, 250);
                        zufallr = rdm.Next(388, 478);
                    }
                }

                if (alienyposi > 800)
                {
                    alienyposi = 0;
                    alienxposi = -100;
                    labelalien.Location = new Point(alienxposi, alienyposi);
                    alienauffeld = false;
                }

                if ((alienyposi + 35 > 500 && alienyposi < 570 && alienxposi + 50 > raumschiffposix && alienxposi < raumschiffposix + 35) && endeläuft == false)
                {
                    geländetimer.Stop();
                    raumschifftimer.Stop();
                    ShowMessage("Crash!", 273);
                    HighscoreSpeichern();
                }

                if (alienyposi + 35 > schussposiy && alienyposi < schussposiy + 15 && alienxposi + 50 > schussposix && alienxposi < schussposix + 5)
                {
                    alienauffeld = false;
                    labelalien.Location = new Point(-100, 0);

                    schussunterwegs = false;
                    rechteckschuss.Location = new Point(-10, 0);
                    schussposix = 0;
                    schussposiy = 900;

                    int zufall = rdm.Next(1, 10);

                    if (zufall == 1 || zufall == 2 || zufall == 3 || zufall == 4)
                    {
                        alienlootscoreauffeld = true;
                        alienlootscorexposi = alienxposi;
                        alienlootscoreyposi = alienyposi;
                        labelalienlootscore.Location = new Point(alienlootscorexposi, alienlootscoreyposi);
                        alienxposi = -100;
                        alienyposi = 0;
                    }

                    if (zufall == 5 || zufall == 6 || zufall == 7 || zufall == 8)
                    {
                        alienlootmuniauffeld = true;
                        alienlootmunixposi = alienxposi;
                        alienlootmuniyposi = alienyposi;
                        labelalienlootmuni.Location = new Point(alienlootmunixposi, alienlootmuniyposi);
                        alienxposi = -100;
                        alienyposi = 0;
                    }

                    if (zufall == 9)
                    {
                        alienlootbombeauffeld = true;
                        alienlootbombexposi = alienxposi;
                        alienlootbombeyposi = alienyposi;
                        labelalienlootbombe.Location = new Point(alienlootbombexposi, alienlootbombeyposi);
                        alienxposi = -100;
                        alienyposi = 0;
                    }

                }

                if (alienyposi + 35 > schuss2posiy && alienyposi < schuss2posiy + 15 && alienxposi + 50 > schuss2posix && alienxposi < schuss2posix + 5)
                {
                    alienauffeld = false;
                    labelalien.Location = new Point(-100, 0);

                    schuss2auffeld = false;
                    rechteckschuss2.Location = new Point(-10, 0);
                    schuss2posix = 0;
                    schuss2posiy = 900;

                    int zufall = rdm.Next(1, 10);

                    if (zufall == 1 || zufall == 2 || zufall == 3 || zufall == 4)
                    {
                        alienlootscoreauffeld = true;
                        alienlootscorexposi = alienxposi;
                        alienlootscoreyposi = alienyposi;
                        labelalienlootscore.Location = new Point(alienlootscorexposi, alienlootscoreyposi);
                        alienxposi = -100;
                        alienyposi = 0;
                    }

                    if (zufall == 5 || zufall == 6 || zufall == 7 || zufall == 8)
                    {
                        alienlootmuniauffeld = true;
                        alienlootmunixposi = alienxposi;
                        alienlootmuniyposi = alienyposi;
                        labelalienlootmuni.Location = new Point(alienlootmunixposi, alienlootmuniyposi);
                        alienxposi = -100;
                        alienyposi = 0;
                    }

                    if (zufall == 9)
                    {
                        alienlootbombeauffeld = true;
                        alienlootbombexposi = alienxposi;
                        alienlootbombeyposi = alienyposi;
                        labelalienlootbombe.Location = new Point(alienlootbombexposi, alienlootbombeyposi);
                        alienxposi = -100;
                        alienyposi = 0;
                    }

                }

                if (alienyposi + 35 > schuss3posiy && alienyposi < schuss3posiy + 15 && alienxposi + 50 > schuss3posix && alienxposi < schuss3posix + 5)
                {
                    alienauffeld = false;
                    labelalien.Location = new Point(-100, 0);

                    schuss3auffeld = false;
                    rechteckschuss3.Location = new Point(-10, 0);
                    schuss3posix = 0;
                    schuss3posiy = 900;

                    int zufall = rdm.Next(1, 10);

                    if (zufall == 1 || zufall == 2 || zufall == 3 || zufall == 4)
                    {
                        alienlootscoreauffeld = true;
                        alienlootscorexposi = alienxposi;
                        alienlootscoreyposi = alienyposi;
                        labelalienlootscore.Location = new Point(alienlootscorexposi, alienlootscoreyposi);
                        alienxposi = -100;
                        alienyposi = 0;
                    }

                    if (zufall == 5 || zufall == 6 || zufall == 7 || zufall == 8)
                    {
                        alienlootmuniauffeld = true;
                        alienlootmunixposi = alienxposi;
                        alienlootmuniyposi = alienyposi;
                        labelalienlootmuni.Location = new Point(alienlootmunixposi, alienlootmuniyposi);
                        alienxposi = -100;
                        alienyposi = 0;
                    }

                    if (zufall == 9)
                    {
                        alienlootbombeauffeld = true;
                        alienlootbombexposi = alienxposi;
                        alienlootbombeyposi = alienyposi;
                        labelalienlootbombe.Location = new Point(alienlootbombexposi, alienlootbombeyposi);
                        alienxposi = -100;
                        alienyposi = 0;
                    }

                }

                if (alienyposi + 35 > schuss4posiy && alienyposi < schuss4posiy + 15 && alienxposi + 50 > schuss4posix && alienxposi < schuss4posix + 5)
                {
                    alienauffeld = false;
                    labelalien.Location = new Point(-100, 0);

                    schuss4unterwegs = false;
                    rechteckschuss4.Location = new Point(-10, 0);
                    schuss4posix = 0;
                    schuss4posiy = 900;

                    int zufall = rdm.Next(1, 10);

                    if (zufall == 1 || zufall == 2 || zufall == 3 || zufall == 4)
                    {
                        alienlootscoreauffeld = true;
                        alienlootscorexposi = alienxposi;
                        alienlootscoreyposi = alienyposi;
                        labelalienlootscore.Location = new Point(alienlootscorexposi, alienlootscoreyposi);
                        alienxposi = -100;
                        alienyposi = 0;
                    }

                    if (zufall == 5 || zufall == 6 || zufall == 7 || zufall == 8)
                    {
                        alienlootmuniauffeld = true;
                        alienlootmunixposi = alienxposi;
                        alienlootmuniyposi = alienyposi;
                        labelalienlootmuni.Location = new Point(alienlootmunixposi, alienlootmuniyposi);
                        alienxposi = -100;
                        alienyposi = 0;
                    }

                    if (zufall == 9)
                    {
                        alienlootbombeauffeld = true;
                        alienlootbombexposi = alienxposi;
                        alienlootbombeyposi = alienyposi;
                        labelalienlootbombe.Location = new Point(alienlootbombexposi, alienlootbombeyposi);
                        alienxposi = -100;
                        alienyposi = 0;
                    }

                }



            }

            if (alienlootscoreauffeld == true)
            {
                alienlootscoreyposi += 2;
                labelalienlootscore.Location = new Point(alienlootscorexposi, alienlootscoreyposi);

                if (alienlootscoreyposi + 35 > 500 && alienlootscoreyposi < 570 && alienlootscorexposi + 50 > raumschiffposix && alienlootscorexposi < raumschiffposix + 35)
                {
                    alienlootscoreauffeld = false;
                    alienlootscorexposi = -100;
                    alienlootscoreyposi = 0;
                    labelalienlootscore.Location = new Point(alienlootscorexposi, alienlootscoreyposi);
                    score += 5;
                }

                if (alienlootscoreyposi + 35 > schussposiy && alienlootscoreyposi < schussposiy + 15 && alienlootscorexposi+50 > schussposix && alienlootscorexposi < schussposix + 5)
                {
                    score += 7;
                    alienlootscoreauffeld = false;
                    alienlootscorexposi = -100;
                    alienlootscoreyposi = 0;
                    labelalienlootscore.Location = new Point(alienlootscorexposi, alienlootscoreyposi);
                }

                if (alienlootscoreyposi + 35 > schuss2posiy && alienlootscoreyposi < schuss2posiy + 15 && alienlootscorexposi+50 > schuss2posix && alienlootscorexposi < schuss2posix + 5)
                {
                    score += 7;
                    alienlootscoreauffeld = false;
                    alienlootscorexposi = -100;
                    alienlootscoreyposi = 0;
                    labelalienlootscore.Location = new Point(alienlootscorexposi, alienlootscoreyposi);
                }

                if (alienlootscoreyposi + 35 > schuss3posiy && alienlootscoreyposi < schuss3posiy + 15 && alienlootscorexposi+50 > schuss3posix && alienlootscorexposi < schuss3posix + 5)
                {
                    score += 7;
                    alienlootscoreauffeld = false;
                    alienlootscorexposi = -100;
                    alienlootscoreyposi = 0;
                    labelalienlootscore.Location = new Point(alienlootscorexposi, alienlootscoreyposi);
                }

                if (alienlootscoreyposi + 35 > schuss4posiy && alienlootscoreyposi < schuss4posiy + 15 && alienlootscorexposi + 50 > schuss4posix && alienlootscorexposi < schuss4posix + 5)
                {
                    score += 7;
                    alienlootscoreauffeld = false;
                    alienlootscorexposi = -100;
                    alienlootscoreyposi = 0;
                    labelalienlootscore.Location = new Point(alienlootscorexposi, alienlootscoreyposi);
                }

            }

            if (alienlootmuniauffeld == true)
            {
                alienlootmuniyposi += 2;
                labelalienlootmuni.Location = new Point(alienlootmunixposi, alienlootmuniyposi);

                if (alienlootmuniyposi + 35 > 500 && alienlootmuniyposi < 570 && alienlootmunixposi + 50 > raumschiffposix && alienlootmunixposi < raumschiffposix + 35)
                {
                    alienlootmuniauffeld = false;
                    alienlootmunixposi = -100;
                    alienlootmuniyposi = 0;
                    labelalienlootmuni.Location = new Point(alienlootmunixposi, alienlootmuniyposi);
                    munition += 3;
                }

                if (alienlootmuniyposi + 35 > schussposiy && alienlootmuniyposi < schussposiy + 15 && alienlootmunixposi + 50 > schussposix && alienlootmunixposi < schussposix + 5)
                {
                    recklinksxgröße = 150;
                    recklinksxgröße1 = 150;
                    recklinksxgröße2 = 150;
                    recklinksxgröße3 = 150;
                    reckrechtsxgröße = 150;
                    reckrechtsxgröße1 = 150;
                    reckrechtsxgröße2 = 150;
                    reckrechtsxgröße3 = 150;
                    reckrechtsxposi = 488;
                    reckrechtsxposi1 = 488;
                    reckrechtsxposi2 = 488;
                    reckrechtsxposi3 = 488;

                    int zufall = rdm.Next(1, 4);
                    if (zufall == 1)
                    {
                        munition++;
                    }
                    if (zufall == 2)
                    {
                        munition += 2;
                    }

                    try
                    {
                        geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße, recklinksygröße);
                    }
                    catch { }
                    labelrecklinks.Image = geländezerstörtbildl;
                    try
                    {
                        geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße1, recklinksygröße1);
                    }
                    catch { }
                    labelrecklinks1.Image = geländezerstörtbildl;
                    try
                    {
                        geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße2, recklinksygröße2);
                    }
                    catch { }
                    labelrecklinks2.Image = geländezerstörtbildl;
                    try
                    {
                        geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße3, recklinksygröße3);
                    }
                    catch { }
                    labelrecklinks3.Image = geländezerstörtbildl;
                    try
                    {
                        geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße, reckrechtsygröße);
                    }
                    catch { }
                    labelreckrechts.Image = geländezerstörtbildr;
                    try
                    {
                        geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße1, reckrechtsygröße1);
                    }
                    catch { }
                    labelreckrechts1.Image = geländezerstörtbildr;
                    try
                    {
                        geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße2, reckrechtsygröße2);
                    }
                    catch { }
                    labelreckrechts2.Image = geländezerstörtbildr;
                    try
                    {
                        geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße3, reckrechtsygröße3);
                    }
                    catch { }
                    labelreckrechts3.Image = geländezerstörtbildr;

                    schussunterwegs = false;
                    rechteckschuss.Location = new Point(-10, 0);
                    schussposix = 0;
                    schussposiy = 900;

                    alienlootmuniauffeld = false;
                    labelalienlootmuni.Location = new Point(-100, 0);
                    alienlootmunixposi = -100;
                    alienlootmuniyposi = 0;
                }

                if (alienlootmuniyposi + 35 > schuss2posiy && alienlootmuniyposi < schuss2posiy + 15 && alienlootmunixposi+50 > schuss2posix && alienlootmunixposi < schuss2posix + 5)
                {
                    recklinksxgröße = 150;
                    recklinksxgröße1 = 150;
                    recklinksxgröße2 = 150;
                    recklinksxgröße3 = 150;
                    reckrechtsxgröße = 150;
                    reckrechtsxgröße1 = 150;
                    reckrechtsxgröße2 = 150;
                    reckrechtsxgröße3 = 150;
                    reckrechtsxposi = 488;
                    reckrechtsxposi1 = 488;
                    reckrechtsxposi2 = 488;
                    reckrechtsxposi3 = 488;

                    int zufall = rdm.Next(1, 4);
                    if (zufall == 1)
                    {
                        munition++;
                    }
                    if (zufall == 2)
                    {
                        munition += 2;
                    }

                    try
                    {
                        geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße, recklinksygröße);
                    }
                    catch { }
                    labelrecklinks.Image = geländezerstörtbildl;
                    try
                    {
                        geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße1, recklinksygröße1);
                    }
                    catch { }
                    labelrecklinks1.Image = geländezerstörtbildl;
                    try
                    {
                        geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße2, recklinksygröße2);
                    }
                    catch { }
                    labelrecklinks2.Image = geländezerstörtbildl;
                    try
                    {
                        geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße3, recklinksygröße3);
                    }
                    catch { }
                    labelrecklinks3.Image = geländezerstörtbildl;
                    try
                    {
                        geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße, reckrechtsygröße);
                    }
                    catch { }
                    labelreckrechts.Image = geländezerstörtbildr;
                    try
                    {
                        geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße1, reckrechtsygröße1);
                    }
                    catch { }
                    labelreckrechts1.Image = geländezerstörtbildr;
                    try
                    {
                        geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße2, reckrechtsygröße2);
                    }
                    catch { }
                    labelreckrechts2.Image = geländezerstörtbildr;
                    try
                    {
                        geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße3, reckrechtsygröße3);
                    }
                    catch { }
                    labelreckrechts3.Image = geländezerstörtbildr;

                    schuss2auffeld = false;
                    rechteckschuss2.Location = new Point(-10, 0);
                    schuss2posix = 0;
                    schuss2posiy = 900;

                    alienlootmuniauffeld = false;
                    labelalienlootmuni.Location = new Point(-100, 0);
                    alienlootmunixposi = -100;
                    alienlootmuniyposi = 0;
                }

                if (alienlootmuniyposi + 35 > schuss3posiy && alienlootmuniyposi < schuss3posiy + 15 && alienlootmunixposi+50 > schuss3posix && alienlootmunixposi < schuss3posix + 5)
                {
                    recklinksxgröße = 150;
                    recklinksxgröße1 = 150;
                    recklinksxgröße2 = 150;
                    recklinksxgröße3 = 150;
                    reckrechtsxgröße = 150;
                    reckrechtsxgröße1 = 150;
                    reckrechtsxgröße2 = 150;
                    reckrechtsxgröße3 = 150;
                    reckrechtsxposi = 488;
                    reckrechtsxposi1 = 488;
                    reckrechtsxposi2 = 488;
                    reckrechtsxposi3 = 488;

                    int zufall = rdm.Next(1, 4);
                    if (zufall == 1)
                    {
                        munition++;
                    }
                    if (zufall == 2)
                    {
                        munition += 2;
                    }

                    try
                    {
                        geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße, recklinksygröße);
                    }
                    catch { }
                    labelrecklinks.Image = geländezerstörtbildl;
                    try
                    {
                        geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße1, recklinksygröße1);
                    }
                    catch { }
                    labelrecklinks1.Image = geländezerstörtbildl;
                    try
                    {
                        geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße2, recklinksygröße2);
                    }
                    catch { }
                    labelrecklinks2.Image = geländezerstörtbildl;
                    try
                    {
                        geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße3, recklinksygröße3);
                    }
                    catch { }
                    labelrecklinks3.Image = geländezerstörtbildl;
                    try
                    {
                        geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße, reckrechtsygröße);
                    }
                    catch { }
                    labelreckrechts.Image = geländezerstörtbildr;
                    try
                    {
                        geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße1, reckrechtsygröße1);
                    }
                    catch { }
                    labelreckrechts1.Image = geländezerstörtbildr;
                    try
                    {
                        geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße2, reckrechtsygröße2);
                    }
                    catch { }
                    labelreckrechts2.Image = geländezerstörtbildr;
                    try
                    {
                        geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße3, reckrechtsygröße3);
                    }
                    catch { }
                    labelreckrechts3.Image = geländezerstörtbildr;

                    schuss3auffeld = false;
                    rechteckschuss3.Location = new Point(-10, 0);
                    schuss3posix = 0;
                    schuss3posiy = 900;

                    alienlootmuniauffeld = false;
                    labelalienlootmuni.Location = new Point(-100, 0);
                    alienlootmunixposi = -100;
                    alienlootmuniyposi = 0;
                }

                if (alienlootmuniyposi + 35 > schuss4posiy && alienlootmuniyposi < schuss4posiy + 15 && alienlootmunixposi + 50 > schuss4posix && alienlootmunixposi < schuss4posix + 5)
                {
                    recklinksxgröße = 150;
                    recklinksxgröße1 = 150;
                    recklinksxgröße2 = 150;
                    recklinksxgröße3 = 150;
                    reckrechtsxgröße = 150;
                    reckrechtsxgröße1 = 150;
                    reckrechtsxgröße2 = 150;
                    reckrechtsxgröße3 = 150;
                    reckrechtsxposi = 488;
                    reckrechtsxposi1 = 488;
                    reckrechtsxposi2 = 488;
                    reckrechtsxposi3 = 488;

                    int zufall = rdm.Next(1, 4);
                    if (zufall == 1)
                    {
                        munition++;
                    }
                    if (zufall == 2)
                    {
                        munition += 2;
                    }

                    try
                    {
                        geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße, recklinksygröße);
                    }
                    catch { }
                    labelrecklinks.Image = geländezerstörtbildl;
                    try
                    {
                        geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße1, recklinksygröße1);
                    }
                    catch { }
                    labelrecklinks1.Image = geländezerstörtbildl;
                    try
                    {
                        geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße2, recklinksygröße2);
                    }
                    catch { }
                    labelrecklinks2.Image = geländezerstörtbildl;
                    try
                    {
                        geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße3, recklinksygröße3);
                    }
                    catch { }
                    labelrecklinks3.Image = geländezerstörtbildl;
                    try
                    {
                        geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße, reckrechtsygröße);
                    }
                    catch { }
                    labelreckrechts.Image = geländezerstörtbildr;
                    try
                    {
                        geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße1, reckrechtsygröße1);
                    }
                    catch { }
                    labelreckrechts1.Image = geländezerstörtbildr;
                    try
                    {
                        geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße2, reckrechtsygröße2);
                    }
                    catch { }
                    labelreckrechts2.Image = geländezerstörtbildr;
                    try
                    {
                        geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße3, reckrechtsygröße3);
                    }
                    catch { }
                    labelreckrechts3.Image = geländezerstörtbildr;

                    schuss4unterwegs = false;
                    rechteckschuss4.Location = new Point(-10, 0);
                    schuss4posix = 0;
                    schuss4posiy = 900;

                    alienlootmuniauffeld = false;
                    labelalienlootmuni.Location = new Point(-100, 0);
                    alienlootmunixposi = -100;
                    alienlootmuniyposi = 0;
                }

            }

            if (alienlootbombeauffeld == true)
            {
                alienlootbombeyposi += 2;
                labelalienlootbombe.Location = new Point(alienlootbombexposi, alienlootbombeyposi);

                if (alienlootbombeyposi + 35 > 500 && alienlootbombeyposi < 570 && alienlootbombexposi + 50 > raumschiffposix && alienlootbombexposi < raumschiffposix + 35)
                {
                    geländetimer.Stop();
                    raumschifftimer.Stop();
                    HighscoreSpeichern();
                    MessageBox.Show("Crash!");
                }

                if (alienlootbombeyposi + 35 > schussposiy && alienlootbombeyposi < schussposiy + 15 && alienlootbombexposi+50 > schussposix && alienlootbombexposi < schussposix + 5)
                {
                    alienlootbombeauffeld = false;
                    alienlootbombexposi = -100;
                    alienlootbombeyposi = 0;
                    labelalienlootbombe.Location = new Point(-100, 0);

                    schussunterwegs = false;
                    rechteckschuss.Location = new Point(-10, 0);
                    schussposix = 0;
                    schussposiy = 900;
                }

                if (alienlootbombeyposi + 35 > schuss2posiy && alienlootbombeyposi < schuss2posiy + 15 && alienlootbombexposi + 50 > schuss2posix && alienlootbombexposi < schuss2posix + 5)
                {
                    alienlootbombeauffeld = false;
                    alienlootbombexposi = -100;
                    alienlootbombeyposi = 0;
                    labelalienlootbombe.Location = new Point(-100, 0);

                    schuss2auffeld = false;
                    rechteckschuss2.Location = new Point(-10, 0);
                    schuss2posix = 0;
                    schuss2posiy = 900;
                }

                if (alienlootbombeyposi + 35 > schuss3posiy && alienlootbombeyposi < schuss3posiy + 15 && alienlootbombexposi + 50 > schuss3posix && alienlootbombexposi < schuss3posix + 5)
                {
                    alienlootbombeauffeld = false;
                    alienlootbombexposi = -100;
                    alienlootbombeyposi = 0;
                    labelalienlootbombe.Location = new Point(-100, 0);

                    schuss3auffeld = false;
                    rechteckschuss3.Location = new Point(-10, 0);
                    schuss3posix = 0;
                    schuss3posiy = 900;
                }

                if (alienlootbombeyposi + 35 > schuss4posiy && alienlootbombeyposi < schuss4posiy + 15 && alienlootbombexposi + 50 > schuss4posix && alienlootbombexposi < schuss4posix + 5)
                {
                    alienlootbombeauffeld = false;
                    alienlootbombexposi = -100;
                    alienlootbombeyposi = 0;
                    labelalienlootbombe.Location = new Point(-100, 0);

                    schuss4unterwegs = false;
                    rechteckschuss4.Location = new Point(-10, 0);
                    schuss4posix = 0;
                    schuss4posiy = 900;
                }
            }




            textboxscore.Text = "Sc: " + score;
            textboxschuss.Text = "Mu: " + munition;

            Refresh();
        }

        private void Schießen()
        {
            if (schussunterwegs == false)
            {
                if (munition > 0)
                {
                    munition--;
                    schussposix = raumschiffposix + 15;
                    rechteckschuss.Location = new Point(schussposix, 485);
                    schussunterwegs = true;
                    schussposiy = 485;
                }
            }
            else if (schuss4unterwegs == false)
            {
                if (munition > 0)
                {
                    munition--;
                    schuss4posix = raumschiffposix + 15;
                    rechteckschuss4.Location = new Point(schuss4posix, 485);
                    schuss4unterwegs = true;
                    schuss4posiy = 485;
                }
            }
        }
        
        //-------------------------------------------------------------------------------------------------------------------------------

        private void raumschifftimer_Tick(object sender, EventArgs e)
        {
            if (raumschiffxbewegung > 5) { raumschiffxbewegung = 5; }
            if (raumschiffxbewegung < -5) { raumschiffxbewegung = -5; }

            if (score >= 100 && endeschonerlebt == false)
            {
                endeläuft = true;
                endecounter++;
                if (endecounter > 200)
                {
                    raumschiffyposi -= 5;
                    labelraumschiff.Location = new Point(raumschiffposix, raumschiffyposi);
                }
            }

            if (raumschiffyposi < -80)
            {
                raumschifftimer.Stop();
                geländetimer.Stop();
                pictureBoxende.Location = new Point(12, 12);
                HighscoreSpeichern();
                Properties.Settings.Default.endeschonerlebt = true;
                Refresh();
            }

            raumschiffposix += raumschiffxbewegung;
            if (raumschiffposix < 0)
            {
                raumschiffposix = 0;
            }
            else if(raumschiffposix+35>638)
            {
                raumschiffposix = 603;
            }
            labelraumschiff.Location = new Point(raumschiffposix, raumschiffyposi);

            if (schussunterwegs==true)
            {
                schussposiy -= 3;
                rechteckschuss.Location = new Point(schussposix, schussposiy);

                if (munitionyposi + 25 > schussposiy && munitionyposi < schussposiy + 15 && munitionxposi + 25 > schussposix && munitionxposi < schussposix + 5)
                {
                    schussposix = munitionxposi + 10;
                    schussposiy = munitionyposi;
                    schuss2auffeld = true;
                    schuss2posix = munitionxposi;
                    schuss2posiy = munitionyposi + 5;
                    schuss3auffeld = true;
                    schuss3posix = munitionxposi + 20;
                    schuss3posiy = munitionyposi + 5;
                    labelmunition.Location = new Point(-100, 0);
                    munitionauffeld = false;
                    munitionxposi = 0;
                    munitionyposi = 0;

                    int zufall = rdm.Next(1, 3);
                    if (zufall == 1)
                    {
                        munition++;
                    }
                }

                if (scoreyposi + 25 > schussposiy && scoreyposi < schussposiy + 15 && scorexposi + 25 > schussposix && scorexposi < schussposix + 5)
                {
                    score += 3;
                    labelscore.Location = new Point(-100, 0);
                    scorexposi = 0;
                    scoreyposi = 0;
                    scoreauffeld = false;
                }


                if (recklinksyposi + recklinksygröße > schussposiy && recklinksyposi < schussposiy + 15 && schussposix < (recklinksxposi + recklinksxgröße)) { recklinksxgröße = 150; schussunterwegs = false; rechteckschuss.Location = new Point(-10, 0); schussposix = -2000; schussposiy = 900; try { geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße, recklinksygröße); } catch { } labelrecklinks.Image = geländezerstörtbildl; labelrecklinks.Size = new Size(recklinksxgröße, recklinksygröße); }
                if (reckrechtsyposi + reckrechtsygröße > schussposiy && reckrechtsyposi < schussposiy + 15 && schussposix + 5 > reckrechtsxposi) { reckrechtsxgröße = 150; reckrechtsxposi = 488; schussunterwegs = false; rechteckschuss.Location = new Point(-10, 0); schussposix = -2000; schussposiy = 900; try { geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße, reckrechtsygröße);  } catch { } labelreckrechts.Image = geländezerstörtbildr; labelreckrechts.Size = new Size(reckrechtsxgröße, reckrechtsygröße); }
                if (recklinksyposi1 + recklinksygröße1 > schussposiy && recklinksyposi1 < schussposiy + 15 && schussposix < (recklinksxposi1 + recklinksxgröße1)) { recklinksxgröße1 = 150; schussunterwegs = false; rechteckschuss.Location = new Point(-10, 0); schussposix = -2000; schussposiy = 900; try { geländezerstörtbildl=new Bitmap(geländezerstörtbildl,recklinksxgröße1,recklinksygröße1);}catch { } labelrecklinks1.Image = geländezerstörtbildl; labelrecklinks2.Size = new Size(recklinksxgröße2, recklinksygröße2); }
                if (reckrechtsyposi1 + reckrechtsygröße1 > schussposiy && reckrechtsyposi1 < schussposiy + 15 && schussposix + 5 > reckrechtsxposi1) { reckrechtsxgröße1 = 150; reckrechtsxposi1 = 488; schussunterwegs = false; rechteckschuss.Location = new Point(-10, 0); schussposix = -2000; schussposiy = 900; try { geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße1, reckrechtsygröße1); } catch { } labelreckrechts1.Image = geländezerstörtbildr; labelreckrechts1.Size = new Size(reckrechtsxgröße1, reckrechtsygröße1); }
                if (recklinksyposi2 + recklinksygröße2 > schussposiy && recklinksyposi2 < schussposiy + 15 && schussposix < (recklinksxposi2 + recklinksxgröße2)) { recklinksxgröße2 = 150; schussunterwegs = false; rechteckschuss.Location = new Point(-10, 0); schussposix = -2000; schussposiy = 900; try { geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße2, recklinksygröße2); } catch { } labelrecklinks2.Image = geländezerstörtbildl; labelrecklinks2.Size = new Size(recklinksxgröße2, recklinksygröße2); }
                if (reckrechtsyposi2 + reckrechtsygröße2 > schussposiy && reckrechtsyposi2 < schussposiy + 15 && schussposix + 5 > reckrechtsxposi2) { reckrechtsxgröße2 = 150; reckrechtsxposi2 = 488; schussunterwegs = false; rechteckschuss.Location = new Point(-10, 0); schussposix = -2000; schussposiy = 900; try { geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße2, reckrechtsygröße2); } catch { } labelreckrechts2.Image = geländezerstörtbildr; labelreckrechts2.Size = new Size(reckrechtsxgröße2, reckrechtsygröße2); }
                if (recklinksyposi3 + recklinksygröße3 > schussposiy && recklinksyposi3 < schussposiy + 15 && schussposix < (recklinksxposi3 + recklinksxgröße3)) { recklinksxgröße3 = 150; schussunterwegs = false; rechteckschuss.Location = new Point(-10, 0); schussposix = -2000; schussposiy = 900; try { geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße3, recklinksygröße3); } catch { } labelrecklinks3.Image = geländezerstörtbildl; labelrecklinks3.Size = new Size(recklinksxgröße3, recklinksygröße3); }
                if (reckrechtsyposi3 + reckrechtsygröße3 > schussposiy && reckrechtsyposi3 < schussposiy + 15 && schussposix + 5 > reckrechtsxposi3) { reckrechtsxgröße3 = 150; reckrechtsxposi3 = 488; schussunterwegs = false; rechteckschuss.Location = new Point(-10, 0); schussposix = -2000; schussposiy = 900; try { geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße3, reckrechtsygröße3); } catch { } labelreckrechts3.Image = geländezerstörtbildr; labelreckrechts3.Size = new Size(reckrechtsxgröße3, reckrechtsygröße3); }

            }

            if (schuss2auffeld == true)
            {
                schuss2posiy -= 2;
                schuss2posix -= 1;
                rechteckschuss2.Location = new Point(schuss2posix, schuss2posiy);

                if (munitionyposi + 25 > schuss2posiy && munitionyposi < schuss2posiy + 15 && munitionxposi + 25 > schuss2posix && munitionxposi < schuss2posix + 5)
                {
                    schussposix = munitionxposi + 10;
                    schussposiy = munitionyposi;
                    schuss2auffeld = true;
                    schuss2posix = munitionxposi;
                    schuss2posiy = munitionyposi + 5;
                    schuss3auffeld = true;
                    schuss3posix = munitionxposi + 20;
                    schuss3posiy = munitionyposi + 5;
                    labelmunition.Location = new Point(-100, 0);
                    munitionauffeld = false;
                    munitionxposi = 0;
                    munitionyposi = 0;

                    int zufall = rdm.Next(1, 3);
                    if (zufall == 1)
                    {
                        munition++;
                    }
                }

                if (scoreyposi + 25 > schuss2posiy && scoreyposi < schuss2posiy + 15 && scorexposi + 25 > schuss2posix && scorexposi < schuss2posix + 5)
                {
                    score += 3;
                    labelscore.Location = new Point(-100, 0);
                    scorexposi = 0;
                    scoreyposi = 0;
                    scoreauffeld = false;
                }


                if (recklinksyposi + recklinksygröße > schuss2posiy && recklinksyposi < schuss2posiy + 15 && schuss2posix < (recklinksxposi + recklinksxgröße)) { recklinksxgröße = 150; schuss2auffeld = false; rechteckschuss2.Location = new Point(-10, 0); schuss2posix = 0; schuss2posiy = 900;try { geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße, recklinksygröße); } catch { } labelrecklinks.Image = geländezerstörtbildl; labelrecklinks.Size = new Size(recklinksxgröße, recklinksygröße); }
                if (reckrechtsyposi + reckrechtsygröße > schuss2posiy && reckrechtsyposi < schuss2posiy + 15 && schuss2posix + 5 > reckrechtsxposi) { reckrechtsxgröße = 150; reckrechtsxposi = 488; schuss2auffeld = false; rechteckschuss2.Location = new Point(-10, 0); schuss2posix = 0; schuss2posiy = 900; try { geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße, reckrechtsygröße); } catch { } labelreckrechts.Image = geländezerstörtbildr; labelreckrechts.Size = new Size(reckrechtsxgröße, reckrechtsygröße); }
                if (recklinksyposi1 + recklinksygröße1 > schuss2posiy && recklinksyposi1 < schuss2posiy + 15 && schuss2posix < (recklinksxposi1 + recklinksxgröße1)) { recklinksxgröße1 = 150; schuss2auffeld = false; rechteckschuss2.Location = new Point(-10, 0); schuss2posix = 0; schuss2posiy = 900; try { geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße1, recklinksygröße1); } catch { } labelrecklinks1.Image = geländezerstörtbildl; labelrecklinks2.Size = new Size(recklinksxgröße2, recklinksygröße2); }
                if (reckrechtsyposi1 + reckrechtsygröße1 > schuss2posiy && reckrechtsyposi1 < schuss2posiy + 15 && schuss2posix + 5 > reckrechtsxposi1) { reckrechtsxgröße1 = 150; reckrechtsxposi1 = 488; schuss2auffeld = false; rechteckschuss2.Location = new Point(-10, 0); schuss2posix = 0; schuss2posiy = 900; try { geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße1, reckrechtsygröße1); } catch { } labelreckrechts1.Image = geländezerstörtbildr; labelreckrechts1.Size = new Size(reckrechtsxgröße1, reckrechtsygröße1); }
                if (recklinksyposi2 + recklinksygröße2 > schuss2posiy && recklinksyposi2 < schuss2posiy + 15 && schuss2posix < (recklinksxposi2 + recklinksxgröße2)) { recklinksxgröße2 = 150; schuss2auffeld = false; rechteckschuss2.Location = new Point(-10, 0); schuss2posix = 0; schuss2posiy = 900; try { geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße2, recklinksygröße2); } catch { } labelrecklinks2.Image = geländezerstörtbildl; labelrecklinks2.Size = new Size(recklinksxgröße2, recklinksygröße2); }
                if (reckrechtsyposi2 + reckrechtsygröße2 > schuss2posiy && reckrechtsyposi2 < schuss2posiy + 15 && schuss2posix + 5 > reckrechtsxposi2) { reckrechtsxgröße2 = 150; reckrechtsxposi2 = 488; schuss2auffeld = false; rechteckschuss2.Location = new Point(-10, 0); schuss2posix = 0; schuss2posiy = 900; try { geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße2, reckrechtsygröße2); } catch { } labelreckrechts2.Image = geländezerstörtbildr; labelreckrechts2.Size = new Size(reckrechtsxgröße2, reckrechtsygröße2); }
                if (recklinksyposi3 + recklinksygröße3 > schuss2posiy && recklinksyposi3 < schuss2posiy + 15 && schuss2posix < (recklinksxposi3 + recklinksxgröße3)) { recklinksxgröße3 = 150; schuss2auffeld = false; rechteckschuss2.Location = new Point(-10, 0); schuss2posix = 0; schuss2posiy = 900; try { geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße3, recklinksygröße3); } catch { } labelrecklinks3.Image = geländezerstörtbildl; labelrecklinks3.Size = new Size(recklinksxgröße3, recklinksygröße3); }
                if (reckrechtsyposi3 + reckrechtsygröße3 > schuss2posiy && reckrechtsyposi3 < schuss2posiy + 15 && schuss2posix + 5 > reckrechtsxposi3) { reckrechtsxgröße3 = 150; reckrechtsxposi3 = 488; schuss2auffeld = false; rechteckschuss2.Location = new Point(-10, 0); schuss2posix = 0; schuss2posiy = 900; try { geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße3, reckrechtsygröße3); } catch { } labelreckrechts3.Image = geländezerstörtbildr; labelreckrechts3.Size = new Size(reckrechtsxgröße3, reckrechtsygröße3); }

            }

            if (schuss3auffeld == true)
            {
                schuss3posiy -= 2;
                schuss3posix += 1;
                rechteckschuss3.Location = new Point(schuss3posix, schuss3posiy);

                if (munitionyposi + 25 > schuss3posiy && munitionyposi < schuss3posiy + 15 && munitionxposi + 25 > schuss3posix && munitionxposi < schuss3posix + 5)
                {
                    schussposix = munitionxposi + 10;
                    schussposiy = munitionyposi;
                    schuss2auffeld = true;
                    schuss2posix = munitionxposi;
                    schuss2posiy = munitionyposi + 5;
                    schuss3auffeld = true;
                    schuss3posix = munitionxposi + 20;
                    schuss3posiy = munitionyposi + 5;
                    labelmunition.Location = new Point(-100, 0);
                    munitionauffeld = false;
                    munitionxposi = 0;
                    munitionyposi = 0;

                    int zufall = rdm.Next(1, 3);
                    if (zufall == 1)
                    {
                        munition++;
                    }
                }

                if (scoreyposi + 25 > schuss3posiy && scoreyposi < schuss3posiy + 15 && scorexposi + 25 > schuss3posix && scorexposi < schuss3posix + 5)
                {
                    score += 3;
                    labelscore.Location = new Point(-100, 0);
                    scorexposi = 0;
                    scoreyposi = 0;
                    scoreauffeld = false;
                }



                if (recklinksyposi + recklinksygröße > schuss3posiy && recklinksyposi < schuss3posiy + 15 && schuss3posix < (recklinksxposi + recklinksxgröße)) { recklinksxgröße = 150; schuss3auffeld = false; rechteckschuss3.Location = new Point(-10, 0); schuss3posix = 0; schuss3posiy = 900;try { geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße, recklinksygröße); } catch { } labelrecklinks.Image = geländezerstörtbildl; labelrecklinks.Size = new Size(recklinksxgröße, recklinksygröße); }
                if (reckrechtsyposi + reckrechtsygröße > schuss3posiy && reckrechtsyposi < schuss3posiy + 15 && schuss3posix + 5 > reckrechtsxposi) { reckrechtsxgröße = 150; reckrechtsxposi = 488; schuss3auffeld = false; rechteckschuss3.Location = new Point(-10, 0); schuss3posix = 0; schuss3posiy = 900; try { geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße, reckrechtsygröße); } catch { } labelreckrechts.Image = geländezerstörtbildr; labelreckrechts.Size = new Size(reckrechtsxgröße, reckrechtsygröße); }
                if (recklinksyposi1 + recklinksygröße1 > schuss3posiy && recklinksyposi1 < schuss3posiy + 15 && schuss3posix < (recklinksxposi1 + recklinksxgröße1)) { recklinksxgröße1 = 150; schuss3auffeld = false; rechteckschuss3.Location = new Point(-10, 0); schuss3posix = 0; schuss3posiy = 900; try { geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße1, recklinksygröße1); } catch { } labelrecklinks1.Image = geländezerstörtbildl; labelrecklinks1.Size = new Size(recklinksxgröße1, recklinksygröße1); }
                if (reckrechtsyposi1 + reckrechtsygröße1 > schuss3posiy && reckrechtsyposi1 < schuss3posiy + 15 && schuss3posix + 5 > reckrechtsxposi1) { reckrechtsxgröße1 = 150; reckrechtsxposi1 = 488; schuss3auffeld = false; rechteckschuss3.Location = new Point(-10, 0); schuss3posix = 0; schuss3posiy = 900; try { geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße1, reckrechtsygröße1); } catch { } labelreckrechts1.Image = geländezerstörtbildr; labelreckrechts1.Size = new Size(reckrechtsxgröße1, reckrechtsygröße1); }
                if (recklinksyposi2 + recklinksygröße2 > schuss3posiy && recklinksyposi2 < schuss3posiy + 15 && schuss3posix < (recklinksxposi2 + recklinksxgröße2)) { recklinksxgröße2 = 150; schuss3auffeld = false; rechteckschuss3.Location = new Point(-10, 0); schuss3posix = 0; schuss3posiy = 900; try { geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße2, recklinksygröße2); } catch { } labelrecklinks2.Image = geländezerstörtbildl; labelrecklinks2.Size = new Size(recklinksxgröße2, recklinksygröße2); }
                if (reckrechtsyposi2 + reckrechtsygröße2 > schuss3posiy && reckrechtsyposi2 < schuss3posiy + 15 && schuss3posix + 5 > reckrechtsxposi2) { reckrechtsxgröße2 = 150; reckrechtsxposi2 = 488; schuss3auffeld = false; rechteckschuss3.Location = new Point(-10, 0); schuss3posix = 0; schuss3posiy = 900; try { geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße2, reckrechtsygröße2); } catch { } labelreckrechts2.Image = geländezerstörtbildr; labelreckrechts2.Size = new Size(reckrechtsxgröße2, reckrechtsygröße2); }
                if (recklinksyposi3 + recklinksygröße3 > schuss3posiy && recklinksyposi3 < schuss3posiy + 15 && schuss3posix < (recklinksxposi3 + recklinksxgröße3)) { recklinksxgröße3 = 150; schuss3auffeld = false; rechteckschuss3.Location = new Point(-10, 0); schuss3posix = 0; schuss3posiy = 900; try { geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße3, recklinksygröße3); } catch { } labelrecklinks3.Image = geländezerstörtbildl; labelrecklinks3.Size = new Size(recklinksxgröße3, recklinksygröße3); }
                if (reckrechtsyposi3 + reckrechtsygröße3 > schuss3posiy && reckrechtsyposi3 < schuss3posiy + 15 && schuss3posix + 5 > reckrechtsxposi3) { reckrechtsxgröße3 = 150; reckrechtsxposi3 = 488; schuss3auffeld = false; rechteckschuss3.Location = new Point(-10, 0); schuss3posix = 0; schuss3posiy = 900; try { geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße3, reckrechtsygröße3); } catch { } labelreckrechts3.Image = geländezerstörtbildr; labelreckrechts3.Size = new Size(reckrechtsxgröße3, reckrechtsygröße3); }

            }

            if (schuss4unterwegs == true)
            {
                schuss4posiy -= 3;
                rechteckschuss4.Location = new Point(schuss4posix, schuss4posiy);

                if (munitionyposi + 25 > schuss4posiy && munitionyposi < schuss4posiy + 15 && munitionxposi + 25 > schuss4posix && munitionxposi < schuss4posix + 5)
                {
                    schuss4posix = munitionxposi + 10;
                    schuss4posiy = munitionyposi;
                    schuss2auffeld = true;
                    schuss2posix = munitionxposi;
                    schuss2posiy = munitionyposi + 5;
                    schuss3auffeld = true;
                    schuss3posix = munitionxposi + 20;
                    schuss3posiy = munitionyposi + 5;
                    labelmunition.Location = new Point(-100, 0);
                    munitionauffeld = false;
                    munitionxposi = 0;
                    munitionyposi = 0;

                    int zufall = rdm.Next(1, 3);
                    if (zufall == 1)
                    {
                        munition++;
                    }
                }

                if (scoreyposi + 25 > schuss4posiy && scoreyposi < schuss4posiy + 15 && scorexposi + 25 > schuss4posix && scorexposi < schuss4posix + 5)
                {
                    score += 3;
                    labelscore.Location = new Point(-100, 0);
                    scorexposi = 0;
                    scoreyposi = 0;
                    scoreauffeld = false;
                }


                if (recklinksyposi + recklinksygröße > schuss4posiy && recklinksyposi < schuss4posiy + 15 && schuss4posix < (recklinksxposi + recklinksxgröße)) { recklinksxgröße = 150; schuss4unterwegs = false; rechteckschuss4.Location = new Point(-10, 0); schuss4posix = -2000; schuss4posiy = 900; try { geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße, recklinksygröße); } catch { } labelrecklinks.Image = geländezerstörtbildl; labelrecklinks.Size = new Size(recklinksxgröße, recklinksygröße); }
                if (reckrechtsyposi + reckrechtsygröße > schuss4posiy && reckrechtsyposi < schuss4posiy + 15 && schuss4posix + 5 > reckrechtsxposi) { reckrechtsxgröße = 150; reckrechtsxposi = 488; schuss4unterwegs = false; rechteckschuss4.Location = new Point(-10, 0); schuss4posix = -2000; schuss4posiy = 900; try { geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße, reckrechtsygröße); } catch { } labelreckrechts.Image = geländezerstörtbildr; labelreckrechts.Size = new Size(reckrechtsxgröße, reckrechtsygröße); }
                if (recklinksyposi1 + recklinksygröße1 > schuss4posiy && recklinksyposi1 < schuss4posiy + 15 && schuss4posix < (recklinksxposi1 + recklinksxgröße1)) { recklinksxgröße1 = 150; schuss4unterwegs = false; rechteckschuss4.Location = new Point(-10, 0); schuss4posix = -2000; schuss4posiy = 900; try { geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße1, recklinksygröße1); } catch { } labelrecklinks1.Image = geländezerstörtbildl; labelrecklinks2.Size = new Size(recklinksxgröße2, recklinksygröße2); }
                if (reckrechtsyposi1 + reckrechtsygröße1 > schuss4posiy && reckrechtsyposi1 < schuss4posiy + 15 && schuss4posix + 5 > reckrechtsxposi1) { reckrechtsxgröße1 = 150; reckrechtsxposi1 = 488; schuss4unterwegs = false; rechteckschuss4.Location = new Point(-10, 0); schuss4posix = -2000; schuss4posiy = 900; try { geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße1, reckrechtsygröße1); } catch { } labelreckrechts1.Image = geländezerstörtbildr; labelreckrechts1.Size = new Size(reckrechtsxgröße1, reckrechtsygröße1); }
                if (recklinksyposi2 + recklinksygröße2 > schuss4posiy && recklinksyposi2 < schuss4posiy + 15 && schuss4posix < (recklinksxposi2 + recklinksxgröße2)) { recklinksxgröße2 = 150; schuss4unterwegs = false; rechteckschuss4.Location = new Point(-10, 0); schuss4posix = -2000; schuss4posiy = 900; try { geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße2, recklinksygröße2); } catch { } labelrecklinks2.Image = geländezerstörtbildl; labelrecklinks2.Size = new Size(recklinksxgröße2, recklinksygröße2); }
                if (reckrechtsyposi2 + reckrechtsygröße2 > schuss4posiy && reckrechtsyposi2 < schuss4posiy + 15 && schuss4posix + 5 > reckrechtsxposi2) { reckrechtsxgröße2 = 150; reckrechtsxposi2 = 488; schuss4unterwegs = false; rechteckschuss4.Location = new Point(-10, 0); schuss4posix = -2000; schuss4posiy = 900; try { geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße2, reckrechtsygröße2); } catch { } labelreckrechts2.Image = geländezerstörtbildr; labelreckrechts2.Size = new Size(reckrechtsxgröße2, reckrechtsygröße2); }
                if (recklinksyposi3 + recklinksygröße3 > schuss4posiy && recklinksyposi3 < schuss4posiy + 15 && schuss4posix < (recklinksxposi3 + recklinksxgröße3)) { recklinksxgröße3 = 150; schuss4unterwegs = false; rechteckschuss4.Location = new Point(-10, 0); schuss4posix = -2000; schuss4posiy = 900; try { geländezerstörtbildl = new Bitmap(geländezerstörtbildl, recklinksxgröße3, recklinksygröße3); } catch { } labelrecklinks3.Image = geländezerstörtbildl; labelrecklinks3.Size = new Size(recklinksxgröße3, recklinksygröße3); }
                if (reckrechtsyposi3 + reckrechtsygröße3 > schuss4posiy && reckrechtsyposi3 < schuss4posiy + 15 && schuss4posix + 5 > reckrechtsxposi3) { reckrechtsxgröße3 = 150; reckrechtsxposi3 = 488; schuss4unterwegs = false; rechteckschuss4.Location = new Point(-10, 0); schuss4posix = -2000; schuss4posiy = 900; try { geländezerstörtbildr = new Bitmap(geländezerstörtbildr, reckrechtsxgröße3, reckrechtsygröße3); } catch { } labelreckrechts3.Image = geländezerstörtbildr; labelreckrechts3.Size = new Size(reckrechtsxgröße3, reckrechtsygröße3); }

            }


            if (munitionyposi > 1000)
            {
                labelmunition.Location = new Point(-100, 0);
                munitionauffeld = false;
                munitionxposi = 0;
                munitionyposi = 0;
            }

            if (scoreyposi > 1000)
            {
                labelscore.Location = new Point(-100, 0);
                scorexposi = 0;
                scoreyposi = 0;
                scoreauffeld = false;
            }
            
            timercounter++;
            textboxtimer.Text = "" + timercounter;

            Refresh();
        }

        private void ShowMessage(string message, int xposi)
        {
            labelmessage.Text = message;
            labelmessage.Location = new Point(xposi, 0);
            messagecounter = 0;
        }
        

        private void HighscoreSpeichern()
        {

            if (hs < score)
            {
                ShowMessage("Neuer Highscore!", 225);
                Properties.Settings.Default.highscore = score;
                Properties.Settings.Default.Save();
            }
            
        }
        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                raumschiffxbewegung = -5;
                steuerungscounter++;
            }
            if (e.KeyCode == Keys.Right)
            {
                raumschiffxbewegung = 5;
                steuerungscounter++;
            }
            if (e.KeyCode == Keys.Down)
            {
                Schießen();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                raumschiffxbewegung = 0;
                steuerungscounter = 0;
            }
        }

        private void buttonstart_Click(object sender, EventArgs e)
        {
            raumschifftimer.Enabled=true;
            raumschifftimer.Start();
            geländetimer.Start();
            labeltutorial.Location = new Point(-200, 0);
            buttonstart.Text = "Neustart";


            labelrecklinks.Location = new Point(0, -10);
            labelreckrechts.Location = new Point(438,-10);
            labelrecklinks.Size = new Size(200,200);
            labelreckrechts.Size = new Size(200,200);

            labelrecklinks1.Location = new Point(0,0);
            labelreckrechts1.Location = new Point(0, 0);
            labelrecklinks1.Size = new Size(0, 0);
            labelreckrechts1.Size = new Size(0, 0);

            labelrecklinks2.Location = new Point(0, 0);
            labelreckrechts2.Location = new Point(0, 0);
            labelrecklinks2.Size = new Size(0, 0);
            labelreckrechts2.Size = new Size(0, 0);

            labelrecklinks3.Location = new Point(0, 0);
            labelreckrechts3.Location = new Point(0, 0);
            labelrecklinks3.Size = new Size(0, 0);
            labelreckrechts3.Size = new Size(0, 0);


            recklinksxposi = 0; recklinksyposi = -10; recklinksxgröße = 200; recklinksygröße = 200;
            reckrechtsxposi = 438; reckrechtsyposi = -10; reckrechtsxgröße = 200; reckrechtsygröße = 200;

            recklinksxposi1 = 0; recklinksyposi1 = 0; recklinksxgröße1 = 0; recklinksygröße1 = 0;
            reckrechtsxposi1 = 0; reckrechtsyposi1 = 0; reckrechtsxgröße1 = 0; reckrechtsygröße1 = 0;

            recklinksxposi2 = 0; recklinksyposi2 = 0; recklinksxgröße2 = 0; recklinksygröße2 = 0;
            reckrechtsxposi2 = 0; reckrechtsyposi2 = 0; reckrechtsxgröße2 = 0; reckrechtsygröße2 = 0;

            recklinksxposi3 = 0; recklinksyposi3 = 0; recklinksxgröße3 = 0; recklinksygröße3 = 0;
            reckrechtsxposi3 = 0; reckrechtsyposi3 = 0; reckrechtsxgröße3 = 0; reckrechtsygröße3 = -500;

            counterlinks = 0;
            counterrechts = 0;
            
            schussposiy = 700; schussposix = 0; schuss2posix = 0; schuss2posiy = 700; schuss3posix = 0; schuss3posiy=700;

            rechteckschuss.Location = new Point(-10, 0);
            rechteckschuss2.Location = new Point(-10, 0);
            rechteckschuss3.Location = new Point(-10, 0);
            rechteckschuss4.Location = new Point(-10, 0);

            labelscore.Location = new Point(-100, 0);
            labelmunition.Location = new Point(-100, 0);
            scorexposi = -100; scoreyposi = 0; munitionxposi = -100; munitionyposi = 0;

            labelalienlootmuni.Location = new Point(-100, 0);
            labelalienlootscore.Location = new Point(-100, 0);
            labelalienlootbombe.Location = new Point(-100, 0);
            alienlootscorexposi = -100; alienlootscoreyposi = 0; alienlootmunixposi = -100; alienlootmuniyposi = 0; alienlootbombexposi = -100;alienlootbombeyposi = 0;

            alienxposi = -100;
            alienyposi = 0;
            labelalien.Location = new Point(-100, 0);

            alienlootscorexposi = -100; alienlootscoreyposi = 0; alienlootmunixposi = -100; alienlootmuniyposi = 0; alienlootbombexposi = -100; alienlootbombeyposi = 0;

            warnunglinks = false; warnungrechts = false; schussunterwegs = false; munitionauffeld = false; scoreauffeld = false; schuss2auffeld = false; schuss3auffeld = false; alienauffeld = false; aliennachlinks = true; alienlootscoreauffeld = false; alienlootmuniauffeld = false; alienlootbombeauffeld = false;

            score = 0; munition = 3;

            timercounter = 0;

            steuerungscounter = 0;

            schuss4posiy = 700; schuss4posix = 0;

            score25 = false; score50 = false; score75 = false; schuss4unterwegs = false;

            messagecounter = 100;
            labelmessage.Location = new Point(700, 0);

            labelrecklinks.Image = geländebild;
            labelrecklinks1.Image = geländebild;
            labelrecklinks2.Image = geländebild;
            labelrecklinks3.Image = geländebild;
            labelreckrechts.Image = geländebild;
            labelreckrechts1.Image = geländebild;
            labelreckrechts2.Image = geländebild;
            labelreckrechts3.Image = geländebild;

            endeläuft = false;

            endecounter = 0;

            raumschiffyposi = 500;

            //ShowMessage("Neuer Highscore!", 225);

        }

    }
}
