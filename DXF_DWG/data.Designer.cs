using System.Windows.Forms;

namespace DXF_DWG
{
    partial class Data
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Data));
            this.comboBox_col_layer = new System.Windows.Forms.ComboBox();
            this.comboBox_wall_layer = new System.Windows.Forms.ComboBox();
            this.label_wall = new System.Windows.Forms.Label();
            this.label_col = new System.Windows.Forms.Label();
            this.comboBox_floor_layer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.comboBox_top_level = new System.Windows.Forms.ComboBox();
            this.comboBox_base_level = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBox_col_layer
            // 
            this.comboBox_col_layer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_col_layer.FormattingEnabled = true;
            this.comboBox_col_layer.Location = new System.Drawing.Point(105, 57);
            this.comboBox_col_layer.Name = "comboBox_col_layer";
            this.comboBox_col_layer.Size = new System.Drawing.Size(121, 21);
            this.comboBox_col_layer.TabIndex = 14;
            // 
            // comboBox_wall_layer
            // 
            this.comboBox_wall_layer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_wall_layer.FormattingEnabled = true;
            this.comboBox_wall_layer.Location = new System.Drawing.Point(105, 16);
            this.comboBox_wall_layer.Name = "comboBox_wall_layer";
            this.comboBox_wall_layer.Size = new System.Drawing.Size(121, 21);
            this.comboBox_wall_layer.TabIndex = 13;
            // 
            // label_wall
            // 
            this.label_wall.AutoSize = true;
            this.label_wall.Location = new System.Drawing.Point(20, 24);
            this.label_wall.Name = "label_wall";
            this.label_wall.Size = new System.Drawing.Size(57, 13);
            this.label_wall.TabIndex = 12;
            this.label_wall.Text = "Wall Layer";
            // 
            // label_col
            // 
            this.label_col.AutoSize = true;
            this.label_col.Location = new System.Drawing.Point(17, 60);
            this.label_col.Name = "label_col";
            this.label_col.Size = new System.Drawing.Size(72, 13);
            this.label_col.TabIndex = 11;
            this.label_col.Text = "Column Layer";
            // 
            // comboBox_floor_layer
            // 
            this.comboBox_floor_layer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_floor_layer.FormattingEnabled = true;
            this.comboBox_floor_layer.Location = new System.Drawing.Point(105, 97);
            this.comboBox_floor_layer.Name = "comboBox_floor_layer";
            this.comboBox_floor_layer.Size = new System.Drawing.Size(121, 21);
            this.comboBox_floor_layer.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Floor Layer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Base Level";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Top Level";
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(151, 136);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 22;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            // 
            // button_cancel
            // 
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(271, 136);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 23;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            // 
            // comboBox_top_level
            // 
            this.comboBox_top_level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_top_level.FormattingEnabled = true;
            this.comboBox_top_level.Location = new System.Drawing.Point(317, 57);
            this.comboBox_top_level.Name = "comboBox_top_level";
            this.comboBox_top_level.Size = new System.Drawing.Size(121, 21);
            this.comboBox_top_level.TabIndex = 24;
            // 
            // comboBox_base_level
            // 
            this.comboBox_base_level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_base_level.FormattingEnabled = true;
            this.comboBox_base_level.Location = new System.Drawing.Point(317, 16);
            this.comboBox_base_level.Name = "comboBox_base_level";
            this.comboBox_base_level.Size = new System.Drawing.Size(121, 21);
            this.comboBox_base_level.TabIndex = 25;
            // 
            // Data
            // 
            this.AcceptButton = this.button_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancel;
            this.ClientSize = new System.Drawing.Size(453, 168);
            this.Controls.Add(this.comboBox_base_level);
            this.Controls.Add(this.comboBox_top_level);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_floor_layer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_col_layer);
            this.Controls.Add(this.comboBox_wall_layer);
            this.Controls.Add(this.label_wall);
            this.Controls.Add(this.label_col);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Data";
            this.Text = "Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_col_layer;
        private System.Windows.Forms.ComboBox comboBox_wall_layer;
        private System.Windows.Forms.Label label_wall;
        private System.Windows.Forms.Label label_col;
        private System.Windows.Forms.ComboBox comboBox_floor_layer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Button button_ok;
        private Button button_cancel;
        private ComboBox comboBox_top_level;
        private ComboBox comboBox_base_level;

        public ComboBox ComboBox_col_layer { get => comboBox_col_layer; set => comboBox_col_layer = value; }
        public ComboBox ComboBox_wall_layer { get => comboBox_wall_layer; set => comboBox_wall_layer = value; }
        public ComboBox ComboBox_floor_layer { get => comboBox_floor_layer; set => comboBox_floor_layer = value; }
        public Label Label_wall { get => label_wall; set => label_wall = value; }
        public Label Label_col { get => label_col; set => label_col = value; }
        public Label Label1 { get => label1; set => label1 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        public Button Button_cancel { get => button_cancel; set => button_cancel = value; }
        public Button Button_ok { get => button_ok; set => button_ok = value; }
        public ComboBox ComboBox_top_level { get => comboBox_top_level; set => comboBox_top_level = value; }
        public ComboBox ComboBox_base_level { get => comboBox_base_level; set => comboBox_base_level = value; }
    }
}