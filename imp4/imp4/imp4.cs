using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace imp4
{
    public partial class imp4 : Form
    {
        public imp4 ( )
        {
            InitializeComponent ();
        }

        String filePath;

        private void button1_Click ( object sender, EventArgs e )
        {
            if ( dOpen.ShowDialog () == DialogResult.OK ) {
                filePath = dOpen.FileName;
                pictureBox1.Image = new Bitmap( dOpen.OpenFile ());
            }
        }

        private void canny ( ) {

            //I get the bitmap from the image loaded
            Bitmap b = new Bitmap (pictureBox1.Image);
            int width = b.Width;
            int height = b.Height;

            int[,] allPixR = new int[width, height];
            int[,] allPixG = new int[width, height];
            int[,] allPixB = new int[width, height];

            //Decompose the image in R, G and B
            for ( int i = 0; i < width; i++ )
            {
                for ( int j = 0; j < height; j++ )
                {
                    allPixR[i, j] = b.GetPixel (i, j).R;
                    allPixG[i, j] = b.GetPixel (i, j).G;
                    allPixB[i, j] = b.GetPixel (i, j).B;
                }
            }

            int[,] allPixRn = new int[width, height];
            int[,] allPixGn = new int[width, height];
            int[,] allPixBn = new int[width, height];

            //Apply Gaussian filter (convolution of the 2 matrices)
            //The Gaussian matrix is:
            //{{1,4,7,4,1}, {4,16,26,15,4}, {7,26,41,26,7}, {4,16,26,16,4}, {1,4,7,4,1}} (it's symmetric)
            for ( int i = 2; i < b.Width - 2; i++ )
            {
                for ( int j = 2; j < b.Height - 2; j++ )
                {
                    int red = (
                              ( ( allPixR [i - 2, j - 2] ) * 1 + ( allPixR [i - 1, j - 2] ) * 4 + ( allPixR [i, j - 2] ) * 7 + ( allPixR [i + 1, j - 2] ) * 4 + ( allPixR [i + 2, j - 2] )
                              + ( allPixR [i - 2, j - 1] ) * 4 + ( allPixR [i - 1, j - 1] ) * 16 + ( allPixR [i, j - 1] ) * 26 + ( allPixR [i + 1, j - 1] ) * 16 + ( allPixR [i + 2, j - 1] ) * 4
                              + ( allPixR [i - 2, j] ) * 7 + ( allPixR [i - 1, j] ) * 26 + ( allPixR [i, j] ) * 41 + ( allPixR [i + 1, j] ) * 26 + ( allPixR [i + 2, j] ) * 7
                              + ( allPixR [i - 2, j + 1] ) * 4 + ( allPixR [i - 1, j + 1] ) * 16 + ( allPixR [i, j + 1] ) * 26 + ( allPixR [i + 1, j + 1] ) * 16 + ( allPixR [i + 2, j + 1] ) * 4
                              + ( allPixR [i - 2, j + 2] ) * 1 + ( allPixR [i - 1, j + 2] ) * 4 + ( allPixR [i, j + 2] ) * 7 + ( allPixR [i + 1, j + 2] ) * 4 + ( allPixR [i + 2, j + 2] ) * 1 ) / 273
                              );

                    int green = (
                              ( ( allPixG[i - 2, j - 2] ) * 1 + ( allPixG[i - 1, j - 2] ) * 4 + ( allPixG[i, j - 2] ) * 7 + ( allPixG[i + 1, j - 2] ) * 4 + ( allPixG[i + 2, j - 2] )
                              + ( allPixG[i - 2, j - 1] ) * 4 + ( allPixG[i - 1, j - 1] ) * 16 + ( allPixG[i, j - 1] ) * 26 + ( allPixG[i + 1, j - 1] ) * 16 + ( allPixG[i + 2, j - 1] ) * 4
                              + ( allPixG[i - 2, j] ) * 7 + ( allPixG[i - 1, j] ) * 26 + ( allPixG[i, j] ) * 41 + ( allPixG[i + 1, j] ) * 26 + ( allPixG[i + 2, j] ) * 7
                              + ( allPixG[i - 2, j + 1] ) * 4 + ( allPixG[i - 1, j + 1] ) * 16 + ( allPixG[i, j + 1] ) * 26 + ( allPixG[i + 1, j + 1] ) * 16 + ( allPixG[i + 2, j + 1] ) * 4
                              + ( allPixG[i - 2, j + 2] ) * 1 + ( allPixG[i - 1, j + 2] ) * 4 + ( allPixG[i, j + 2] ) * 7 + ( allPixG[i + 1, j + 2] ) * 4 + ( allPixG[i + 2, j + 2] ) * 1 ) / 273
                              );

                    int blue = (
                              ( ( allPixB[i - 2, j - 2] ) * 1 + ( allPixB[i - 1, j - 2] ) * 4 + ( allPixB[i, j - 2] ) * 7 + ( allPixB[i + 1, j - 2] ) * 4 + ( allPixB[i + 2, j - 2] )
                              + ( allPixB[i - 2, j - 1] ) * 4 + ( allPixB[i - 1, j - 1] ) * 16 + ( allPixB[i, j - 1] ) * 26 + ( allPixB[i + 1, j - 1] ) * 16 + ( allPixB[i + 2, j - 1] ) * 4
                              + ( allPixB[i - 2, j] ) * 7 + ( allPixB[i - 1, j] ) * 26 + ( allPixB[i, j] ) * 41 + ( allPixB[i + 1, j] ) * 26 + ( allPixB[i + 2, j] ) * 7
                              + ( allPixB[i - 2, j + 1] ) * 4 + ( allPixB[i - 1, j + 1] ) * 16 + ( allPixB[i, j + 1] ) * 26 + ( allPixB[i + 1, j + 1] ) * 16 + ( allPixB[i + 2, j + 1] ) * 4
                              + ( allPixB[i - 2, j + 2] ) * 1 + ( allPixB[i - 1, j + 2] ) * 4 + ( allPixB[i, j + 2] ) * 7 + ( allPixB[i + 1, j + 2] ) * 4 + ( allPixB[i + 2, j + 2] ) * 1 ) / 273
                              );

                    //The pixels with i<2 or j<2 will be 0, as before (when we were using the n matrix)
                    allPixRn[i, j] = red;
                    allPixGn[i, j] = green;
                    allPixBn[i, j] = blue;
                }
            }
            //Now allPixRn, allPixGn and allPixBn have a blurred version of the original image (separated in Red, Green and Blue).
            //They is not affected by a single noisy pixel by any significant degree


            //Now I use the Sobel operator to get the derivatives
            //Note: I could do this also with Roberts or Prewitt
            //Get the value for the first derivative in the horizontal direction
            int[,] gx = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };

            //Get the value for the first derivative in the vertical direction
            int[,] gy = new int[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

            int new_rx = 0, new_ry = 0;
            int new_gx = 0, new_gy = 0;
            int new_bx = 0, new_by = 0;
            int rc, gc, bc;
            int gradR, gradG, gradB;

            //Map of gradientes declaration (for Red, Green and Blue)
            int[,] graidientR = new int [width, height];
            int[,] graidientG = new int [width, height];
            int[,] graidientB = new int [width, height];

            int atanR,atanG,atanB;

            int[,] tanR = new int[width, height];
            int[,] tanG = new int[width, height];
            int[,] tanB = new int[width, height];

            //int limit = 128 * 128;
            //Bitmap bb = new Bitmap (pictureBox1.Image);

            for ( int i = 1; i < b.Width - 1; i++ )
            {
                for ( int j = 1; j < b.Height - 1; j++ )
                {

                    new_rx = 0;
                    new_ry = 0;
                    new_gx = 0;
                    new_gy = 0;
                    new_bx = 0;
                    new_by = 0;
                    rc = 0;
                    gc = 0;
                    bc = 0;

                    // 2-dimensional convolution operation between the matrix gx for the horizontal derivative
                    // Ideam with the matrix gy for the vertical derivative
                    // Do this for R,G and B

                    // Basically, for each pixel P of the Red Matrix (for example), I'm getting its neighbours
                    // To simplify, let's say that I get a 3x3 matrix where P is the (1,1)
                    // For each neighbour N of (1,1) of index (i,j), I'm multiplying it by gx[i,j] and adding that value to horizontal derivative of P
                    // Similarly, I multiply N by gy[i,j] and add the value to the vertical derivative of P
                    //I do that for the Red, Green and Blue matrix (I had decomposed the blurred image in these three matrices)
                    for ( int wi = -1; wi < 2; wi++ )
                    {
                        for ( int hw = -1; hw < 2; hw++ )
                        {
                            rc = allPixRn[i + hw, j + wi];
                            new_rx += gx[wi + 1, hw + 1] * rc;
                            new_ry += gy[wi + 1, hw + 1] * rc;

                            gc = allPixGn[i + hw, j + wi];
                            new_gx += gx[wi + 1, hw + 1] * gc;
                            new_gy += gy[wi + 1, hw + 1] * gc;

                            bc = allPixBn[i + hw, j + wi];
                            new_bx += gx[wi + 1, hw + 1] * bc;
                            new_by += gy[wi + 1, hw + 1] * bc;
                        }
                    }

                    //Find gradient (its the norm of (new_rx, new_ry))
                    //Do this for R, G, and B
                    gradR = (int)Math.Sqrt((new_rx * new_rx) + (new_ry * new_ry));
                    graidientR [i,j]= gradR; 

                    gradG = (int)Math.Sqrt (( new_gx * new_gx ) + ( new_gy * new_gy ));
                    graidientG [i,j]= gradG; 

                    gradB = (int)Math.Sqrt (( new_bx * new_gx ) + ( new_by * new_by ));
                    graidientB [i,j]= gradB;


                    //find tans
                    ////////////////tan red//////////////////////////////////

                    //Calculate tan(vertical_derivative/horizontal_derivative). The result is in radians, so I multiply it by 180/PI

                    atanR= (int)( ( Math.Atan ((double)new_ry / new_rx) ) * ( 180 / Math.PI ) );

                    //Once I get the arctangent, I round it to 4 possible directions.
                    if ( (atanR > 0 && atanR < 22.5) || (atanR > 157.5 && atanR < 180) )
                    {
                        atanR = 0;
                    }
                    else if (atanR > 22.5 && atanR < 67.5){
                        atanR = 45;
                    }
                    else if (atanR > 67.5 && atanR < 112.5){
                        atanR = 90;
                    }
                    else if (atanR > 112.5 && atanR < 157.5) {
                        atanR = 135;
                    }


                    //Now I surrogate the 4 possible values to 0,1,2,3 in the atangent matrix
                    if ( atanR == 0 )
                    {
                        tanR[i, j] = 0;
                    }
                    else if ( atanR == 45 )
                    {
                        tanR[i, j] = 1;
                    }
                    else if ( atanR == 90 )
                    {
                        tanR[i, j] = 2;
                    }
                    else if ( atanR == 135 )
                    {
                        tanR[i, j] = 3;
                    }
                    ////////////////tan red end//////////////////////////////////

                    ////////////////tan green//////////////////////////////////
                    //I do the same thing for green
                    atanG = (int)( ( Math.Atan ((double)new_gy / new_gx) ) * ( 180 / Math.PI ) );
                    if ( ( atanG > 0 && atanG < 22.5 ) || ( atanG > 157.5 && atanG < 180 ) )
                    {
                        atanG = 0;
                    }
                    else if ( atanG > 22.5 && atanG < 67.5 )
                    {
                        atanG = 45;
                    }
                    else if ( atanG > 67.5 && atanG < 112.5 )
                    {
                        atanG = 90;
                    }
                    else if ( atanG > 112.5 && atanG < 157.5 )
                    {
                        atanG = 135;
                    }


                    if (atanG == 0){
                        tanG[i, j] = 0;
                    }
                    else if (atanG == 45) {
                        tanG[i, j] = 1;
                    }
                    else if ( atanG == 90 )
                    {
                        tanG[i, j] = 2;
                    }
                    else if ( atanG == 135 )
                    {
                        tanG[i, j] = 3;
                    }
                    ////////////////tan green end//////////////////////////////////

                    ////////////////tan blue//////////////////////////////////
                    //And the same for blue
                    atanB = (int)( ( Math.Atan ((double)new_by / new_bx) ) * ( 180 / Math.PI ) );
                    if ( ( atanB > 0 && atanB < 22.5 ) || ( atanB > 157.5 && atanB < 180 ) )
                    {
                        atanB = 0;
                    }
                    else if ( atanB > 22.5 && atanB < 67.5 )
                    {
                        atanB = 45;
                    }
                    else if ( atanB > 67.5 && atanB < 112.5 )
                    {
                        atanB = 90;
                    }
                    else if ( atanB > 112.5 && atanB < 157.5 )
                    {
                        atanB = 135;
                    }

                    if ( atanB == 0 )
                    {
                        tanB[i, j] = 0;
                    }
                    else if ( atanB == 45 )
                    {
                        tanB[i, j] = 1;
                    }
                    else if ( atanB == 90 )
                    {
                        tanB[i, j] = 2;
                    }
                    else if ( atanB == 135 )
                    {
                        tanB[i, j] = 3;
                    }
                    ////////////////tan blue end//////////////////////////////////
                }
            }

            int[,] allPixRs = new int[width, height];
            int[,] allPixGs = new int[width, height];
            int[,] allPixBs = new int[width, height];

            for ( int i = 2; i < width-2; i++ )
            {
                for ( int j = 2; j < height-2; j++ )
                {

                    ////red
                    if ( tanR[i, j] == 0 )
                    {
                        //the point will not be considered to be on an edge if its gradient magnitude is smaller than the magnitudes at pixels in the east and west directions
                        if ( graidientR[i - 1, j] < graidientR[i, j] && graidientR[i + 1, j] < graidientR[i, j] )
                        {
                            //The point may be considered of an edge, so we keep the value of the gradient (we are only considering the Red Matrix here).
                            //The gradient will also have to be greater than the threshold for the pixel to be considered part of an edge
                            //TODO: add high threshold
                            allPixRs[i, j] = graidientR[i, j];
                        }
                        else {

                            //The point is not in the edge
                            allPixRs[i,j] = 0;
                        }
                    }
                    if ( tanR[i, j] == 1 )
                    {
                        //Same as above. For each of the 4 directions, we draw an imaginary perpendicular line to the tanR that crosses the pixel P we are processing,
                        // and we ask if the gradient magnitude of the 2 neighbours of P that are in that line is bigger or smaller than P's gradient
                        if ( graidientR[i - 1, j + 1] < graidientR[i, j] && graidientR[i + 1, j - 1] < graidientR[i, j] )
                        {
                            allPixRs[i, j] = graidientR[i, j];
                        }
                        else
                        {
                            allPixRs[i, j] = 0;
                        }
                    }
                    if ( tanR[i, j] == 2 )
                    {
                        if ( graidientR[i, j - 1] < graidientR[i, j] && graidientR[i, j + 1] < graidientR[i, j] )
                        {
                            allPixRs[i, j] = graidientR[i, j];
                        }
                        else
                        {
                            allPixRs[i, j] = 0;
                        }
                    }
                    if ( tanR[i, j] == 3 )
                    {
                        if ( graidientR[i - 1, j - 1] < graidientR[i, j] && graidientR[i + 1, j + 1] < graidientR[i, j] )
                        {
                            allPixRs[i, j] = graidientR[i, j];
                        }
                        else
                        {
                            allPixRs[i, j] = 0;
                        }
                    }

                    //Same for green
                    //green
                    if ( tanG[i, j] == 0 )
                    {
                        if ( graidientG[i - 1, j] < graidientG[i, j] && graidientG[i + 1, j] < graidientG[i, j] )
                        {
                            allPixGs[i, j] = graidientG[i, j];
                        }
                        else
                        {
                            allPixGs[i, j] = 0;
                        }
                    }
                    if ( tanG[i, j] == 1 )
                    {
                        if ( graidientG[i - 1, j + 1] < graidientG[i, j] && graidientG[i + 1, j - 1] < graidientG[i, j] )
                        {
                            allPixGs[i, j] = graidientG[i, j];
                        }
                        else
                        {
                            allPixGs[i, j] = 0;
                        }
                    }
                    if ( tanG[i, j] == 2 )
                    {
                        if ( graidientG[i, j - 1] < graidientG[i, j] && graidientG[i, j + 1] < graidientG[i, j] )
                        {
                            allPixGs[i, j] = graidientG[i, j];
                        }
                        else
                        {
                            allPixGs[i, j] = 0;
                        }
                    }
                    if ( tanG[i, j] == 3 )
                    {
                        if ( graidientG[i - 1, j - 1] < graidientG[i, j] && graidientG[i + 1, j + 1] < graidientG[i, j] )
                        {
                            allPixGs[i, j] = graidientG[i, j];
                        }
                        else
                        {
                            allPixGs[i, j] = 0;
                        }
                    }

                    //Same for blue
                    //blue
                    if ( tanB[i, j] == 0 )
                    {
                        if ( graidientB[i - 1, j] < graidientB[i, j] && graidientB[i + 1, j] < graidientB[i, j] )
                        {
                            allPixBs[i, j] = graidientB[i, j];
                        }
                        else
                        {
                            allPixBs[i, j] = 0;
                        }
                    }
                    if ( tanB[i, j] == 1 )
                    {
                        if ( graidientB[i - 1, j + 1] < graidientB[i, j] && graidientB[i + 1, j - 1] < graidientB[i, j] )
                        {
                            allPixBs[i, j] = graidientB[i, j];
                        }
                        else
                        {
                            allPixBs[i, j] = 0;
                        }
                    }
                    if ( tanB[i, j] == 2 )
                    {
                        if ( graidientB[i, j - 1] < graidientB[i, j] && graidientB[i, j + 1] < graidientB[i, j] )
                        {
                            allPixBs[i, j] = graidientB[i, j];
                        }
                        else
                        {
                            allPixBs[i, j] = 0;
                        }
                    }
                    if ( tanB[i, j] == 3 )
                    {
                        if ( graidientB[i - 1, j - 1] < graidientB[i, j] && graidientB[i + 1, j + 1] < graidientB[i, j] )
                        {
                            allPixBs[i, j] = graidientB[i, j];
                        }
                        else
                        {
                            allPixBs[i, j] = 0;
                        }
                    }
                }
            }

            //TODO: fixed threshold?
            int threshold = Convert.ToInt16(textBox1.Text);

            // Bitmap bb = new Bitmap (pictureBox1.Image);
            Bitmap bb = new Bitmap(width,height);

            for (int i = 2; i < width - 2; i++)
            {
                for (int j = 2; j < height - 2; j++)
                {

                    //If any of the values of the gradients is greater than the threshold, then I consider that the pixel belongs to a border, so I light it up
                    if (allPixRs[i, j] > threshold || allPixGs[i, j] > threshold || allPixBs[i, j] > threshold)
                    {
                        //The three
                        bb.SetPixel(i, j, Color.Black);
                    }
                    else
                        bb.SetPixel(i, j, Color.White);
                }
            }
            pictureBox2.Image = bb;        
        }

        private void button3_Click ( object sender, EventArgs e )
        {
            canny ();
        }
    }
}
