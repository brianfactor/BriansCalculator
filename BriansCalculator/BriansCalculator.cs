using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BriansCalculator
{
    public partial class BriansCalculator : Form
    {
        System.Collections.Stack operationsStack;
        int displayValue;

        public BriansCalculator()
        {
            InitializeComponent();
            operationsStack = new System.Collections.Stack();
            clearDisplay();
        }

        /* Utility methods */
        private void clearDisplay() // clear display also clears the state of the data
        {
            display.Text = "";
            displayValue = 0;
            operationsStack.Clear();
        }
        private void insertNumber(int digitNumber)
        {
            displayValue = digitNumber + displayValue * 10;
        }
        private void insertOperation(MathOperation op)
        {
            operationsStack.Push(op);
        }

        private void clear_Click(object sender, EventArgs e)
        {
            clearDisplay();
        }

        /* Number handlers */
        // these would be great candiates for a macro.
        private void one_Click(object sender, EventArgs e)
        {
            display.Text += "1";
            insertNumber(1);
        }
        private void two_Click(object sender, EventArgs e)
        {
            display.Text += "2";
            insertNumber(2);
        }
        private void three_Click(object sender, EventArgs e)
        {
            display.Text += "3";
            insertNumber(3);
        }
        private void four_Click(object sender, EventArgs e)
        {
            display.Text += "4";
            insertNumber(4);
        }
        private void five_Click(object sender, EventArgs e)
        {
            display.Text += "5";
            insertNumber(5);
        }
        private void six_Click(object sender, EventArgs e)
        {
            display.Text += "6";
            insertNumber(6);
        }
        private void seven_Click(object sender, EventArgs e)
        {
            display.Text += "7";
            insertNumber(7);
        }
        private void eight_Click(object sender, EventArgs e)
        {
            display.Text += "8";
            insertNumber(8);
        }
        private void nine_Click(object sender, EventArgs e)
        {
            display.Text += "9";
            insertNumber(9);
        }
        private void zero_Click(object sender, EventArgs e)
        {
            display.Text += "0";
            insertNumber(0);
        }

        /* Operation handlers */
        private void subtract_Click(object sender, EventArgs e)
        {
            display.Text += " - ";
            insertOperation(new Subtraction(displayValue));
            displayValue = 0;
        }

        private void add_Click(object sender, EventArgs e)
        {
            display.Text += " + ";
            insertOperation(new Addition(displayValue));
            displayValue = 0;
        }

        private void equals_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(displayValue.ToString());
            int answerAccumulator = displayValue;
            foreach (MathOperation op in operationsStack)
            {
                answerAccumulator = op.perform(answerAccumulator);
            }
            operationsStack.Clear();
            displayValue = answerAccumulator;
            display.Text = answerAccumulator.ToString();
        }
    }

    /* object to model mathemtical operations */
    public abstract class MathOperation
    {
        protected int leftSide;
        public abstract int perform(int rightSide);
    }
    public class Addition : MathOperation
    {
        public Addition(int leftHandSide)
        {
            leftSide = leftHandSide;
        }
        public override int perform(int rightSide)
        {
            return leftSide + rightSide;
        }
    }
    public class Subtraction : MathOperation
    {
        public Subtraction(int leftHandSide)
        {
            leftSide = leftHandSide;
        }
        public override int perform(int rightSide)
        {
            return leftSide - rightSide;
        }
    }
    // I'm not sure how to handle this one now, since order of operation comes into play. My simple stack doesn't work anymore.
    // ie: 3 * 4 - 2 need to multiply before the subtract takes effect
    public class Multiplication : MathOperation
    {
        public Multiplication(int leftHandSide)
        {
            leftSide = leftHandSide;
        }
        public override int perform(int rightSide)
        {
            return leftSide * rightSide;
        }
    }
}
