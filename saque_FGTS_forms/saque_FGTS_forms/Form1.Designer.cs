
namespace saque_FGTS_forms
{
    partial class frmForm1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSaldoHJ = new System.Windows.Forms.Label();
            this.lblDataNasc = new System.Windows.Forms.Label();
            this.lblDataHJ = new System.Windows.Forms.Label();
            this.lblTaxaAD = new System.Windows.Forms.Label();
            this.lblTaxaAA = new System.Windows.Forms.Label();
            this.lblTaxaAM = new System.Windows.Forms.Label();
            this.txtSaldoHJ = new System.Windows.Forms.TextBox();
            this.txtTaxaAM = new System.Windows.Forms.TextBox();
            this.lblTaxaAResult = new System.Windows.Forms.Label();
            this.lblTaxaDResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.lstSaques = new System.Windows.Forms.ListBox();
            this.lstData = new System.Windows.Forms.ListBox();
            this.lstSaqueAut = new System.Windows.Forms.ListBox();
            this.lstDias = new System.Windows.Forms.ListBox();
            this.lstDesagio = new System.Windows.Forms.ListBox();
            this.lstVP = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblVPbruto = new System.Windows.Forms.Label();
            this.lblIOFBasTotal = new System.Windows.Forms.Label();
            this.lblLiquido = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTotalSaque = new System.Windows.Forms.Label();
            this.dtpHJ = new System.Windows.Forms.DateTimePicker();
            this.dtpPrimSaq = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lstJuros = new System.Windows.Forms.ListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lstIOFBas = new System.Windows.Forms.ListBox();
            this.lstSaldoDev = new System.Windows.Forms.ListBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lstAmortizado = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lstIOFtotal = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalAmo = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblJurosTot = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lstIOFflat = new System.Windows.Forms.ListBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lblTotalFlat = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblIOF = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitulo.Location = new System.Drawing.Point(317, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(299, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Simulador FGTS";
            // 
            // lblSaldoHJ
            // 
            this.lblSaldoHJ.AutoSize = true;
            this.lblSaldoHJ.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSaldoHJ.Location = new System.Drawing.Point(40, 85);
            this.lblSaldoHJ.Name = "lblSaldoHJ";
            this.lblSaldoHJ.Size = new System.Drawing.Size(67, 15);
            this.lblSaldoHJ.TabIndex = 1;
            this.lblSaldoHJ.Text = "Saldo Hoje:";
            // 
            // lblDataNasc
            // 
            this.lblDataNasc.AutoSize = true;
            this.lblDataNasc.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDataNasc.Location = new System.Drawing.Point(40, 132);
            this.lblDataNasc.Name = "lblDataNasc";
            this.lblDataNasc.Size = new System.Drawing.Size(110, 15);
            this.lblDataNasc.TabIndex = 2;
            this.lblDataNasc.Text = "Data de nacimento:";
            // 
            // lblDataHJ
            // 
            this.lblDataHJ.AutoSize = true;
            this.lblDataHJ.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDataHJ.Location = new System.Drawing.Point(40, 176);
            this.lblDataHJ.Name = "lblDataHJ";
            this.lblDataHJ.Size = new System.Drawing.Size(44, 15);
            this.lblDataHJ.TabIndex = 3;
            this.lblDataHJ.Text = "Hoje é:";
            // 
            // lblTaxaAD
            // 
            this.lblTaxaAD.AutoSize = true;
            this.lblTaxaAD.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTaxaAD.Location = new System.Drawing.Point(305, 176);
            this.lblTaxaAD.Name = "lblTaxaAD";
            this.lblTaxaAD.Size = new System.Drawing.Size(69, 15);
            this.lblTaxaAD.TabIndex = 6;
            this.lblTaxaAD.Text = "Taxa ao Dia:";
            // 
            // lblTaxaAA
            // 
            this.lblTaxaAA.AutoSize = true;
            this.lblTaxaAA.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTaxaAA.Location = new System.Drawing.Point(305, 132);
            this.lblTaxaAA.Name = "lblTaxaAA";
            this.lblTaxaAA.Size = new System.Drawing.Size(72, 15);
            this.lblTaxaAA.TabIndex = 5;
            this.lblTaxaAA.Text = "Taxa ao ano:";
            // 
            // lblTaxaAM
            // 
            this.lblTaxaAM.AutoSize = true;
            this.lblTaxaAM.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTaxaAM.Location = new System.Drawing.Point(305, 85);
            this.lblTaxaAM.Name = "lblTaxaAM";
            this.lblTaxaAM.Size = new System.Drawing.Size(74, 15);
            this.lblTaxaAM.TabIndex = 4;
            this.lblTaxaAM.Text = "Taxa ao mês:";
            // 
            // txtSaldoHJ
            // 
            this.txtSaldoHJ.BackColor = System.Drawing.SystemColors.Info;
            this.txtSaldoHJ.Location = new System.Drawing.Point(40, 103);
            this.txtSaldoHJ.Name = "txtSaldoHJ";
            this.txtSaldoHJ.Size = new System.Drawing.Size(141, 23);
            this.txtSaldoHJ.TabIndex = 7;
            // 
            // txtTaxaAM
            // 
            this.txtTaxaAM.BackColor = System.Drawing.SystemColors.Info;
            this.txtTaxaAM.Location = new System.Drawing.Point(305, 103);
            this.txtTaxaAM.Name = "txtTaxaAM";
            this.txtTaxaAM.Size = new System.Drawing.Size(141, 23);
            this.txtTaxaAM.TabIndex = 10;
            // 
            // lblTaxaAResult
            // 
            this.lblTaxaAResult.AutoSize = true;
            this.lblTaxaAResult.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTaxaAResult.Location = new System.Drawing.Point(305, 150);
            this.lblTaxaAResult.Name = "lblTaxaAResult";
            this.lblTaxaAResult.Size = new System.Drawing.Size(13, 15);
            this.lblTaxaAResult.TabIndex = 11;
            this.lblTaxaAResult.Text = "0";
            // 
            // lblTaxaDResult
            // 
            this.lblTaxaDResult.AutoSize = true;
            this.lblTaxaDResult.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTaxaDResult.Location = new System.Drawing.Point(305, 191);
            this.lblTaxaDResult.Name = "lblTaxaDResult";
            this.lblTaxaDResult.Size = new System.Drawing.Size(13, 15);
            this.lblTaxaDResult.TabIndex = 12;
            this.lblTaxaDResult.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(40, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Saques";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(153, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(522, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Saque autorizado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(654, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Dias";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(767, 307);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Deságio";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(878, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Valor Presente";
            // 
            // btnCalcular
            // 
            this.btnCalcular.BackColor = System.Drawing.SystemColors.Info;
            this.btnCalcular.Location = new System.Drawing.Point(305, 217);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(111, 44);
            this.btnCalcular.TabIndex = 20;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = false;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // lstSaques
            // 
            this.lstSaques.BackColor = System.Drawing.SystemColors.Info;
            this.lstSaques.FormattingEnabled = true;
            this.lstSaques.ItemHeight = 15;
            this.lstSaques.Location = new System.Drawing.Point(40, 335);
            this.lstSaques.Name = "lstSaques";
            this.lstSaques.Size = new System.Drawing.Size(89, 139);
            this.lstSaques.TabIndex = 21;
            // 
            // lstData
            // 
            this.lstData.BackColor = System.Drawing.SystemColors.Info;
            this.lstData.FormattingEnabled = true;
            this.lstData.ItemHeight = 15;
            this.lstData.Location = new System.Drawing.Point(153, 335);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(105, 139);
            this.lstData.TabIndex = 22;
            // 
            // lstSaqueAut
            // 
            this.lstSaqueAut.BackColor = System.Drawing.Color.Red;
            this.lstSaqueAut.ForeColor = System.Drawing.SystemColors.Window;
            this.lstSaqueAut.FormattingEnabled = true;
            this.lstSaqueAut.ItemHeight = 15;
            this.lstSaqueAut.Location = new System.Drawing.Point(522, 335);
            this.lstSaqueAut.Name = "lstSaqueAut";
            this.lstSaqueAut.Size = new System.Drawing.Size(109, 139);
            this.lstSaqueAut.TabIndex = 24;
            // 
            // lstDias
            // 
            this.lstDias.BackColor = System.Drawing.SystemColors.Info;
            this.lstDias.FormattingEnabled = true;
            this.lstDias.ItemHeight = 15;
            this.lstDias.Location = new System.Drawing.Point(654, 335);
            this.lstDias.Name = "lstDias";
            this.lstDias.Size = new System.Drawing.Size(89, 139);
            this.lstDias.TabIndex = 25;
            // 
            // lstDesagio
            // 
            this.lstDesagio.BackColor = System.Drawing.SystemColors.Info;
            this.lstDesagio.FormattingEnabled = true;
            this.lstDesagio.ItemHeight = 15;
            this.lstDesagio.Location = new System.Drawing.Point(767, 335);
            this.lstDesagio.Name = "lstDesagio";
            this.lstDesagio.Size = new System.Drawing.Size(89, 139);
            this.lstDesagio.TabIndex = 26;
            // 
            // lstVP
            // 
            this.lstVP.BackColor = System.Drawing.Color.ForestGreen;
            this.lstVP.ForeColor = System.Drawing.SystemColors.Window;
            this.lstVP.FormattingEnabled = true;
            this.lstVP.ItemHeight = 15;
            this.lstVP.Location = new System.Drawing.Point(878, 335);
            this.lstVP.Name = "lstVP";
            this.lstVP.Size = new System.Drawing.Size(89, 139);
            this.lstVP.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.ForestGreen;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(878, 485);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 15);
            this.label8.TabIndex = 28;
            this.label8.Text = "VP bruto:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.ForestGreen;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(620, 244);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 15);
            this.label9.TabIndex = 29;
            this.label9.Text = "Total:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.ForestGreen;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(878, 511);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 15);
            this.label10.TabIndex = 30;
            this.label10.Text = "Valor líqudo:";
            // 
            // lblVPbruto
            // 
            this.lblVPbruto.AutoSize = true;
            this.lblVPbruto.BackColor = System.Drawing.Color.ForestGreen;
            this.lblVPbruto.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblVPbruto.Location = new System.Drawing.Point(930, 485);
            this.lblVPbruto.Name = "lblVPbruto";
            this.lblVPbruto.Size = new System.Drawing.Size(13, 15);
            this.lblVPbruto.TabIndex = 31;
            this.lblVPbruto.Text = "0";
            // 
            // lblIOFBasTotal
            // 
            this.lblIOFBasTotal.AutoSize = true;
            this.lblIOFBasTotal.BackColor = System.Drawing.Color.ForestGreen;
            this.lblIOFBasTotal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblIOFBasTotal.Location = new System.Drawing.Point(655, 244);
            this.lblIOFBasTotal.Name = "lblIOFBasTotal";
            this.lblIOFBasTotal.Size = new System.Drawing.Size(13, 15);
            this.lblIOFBasTotal.TabIndex = 32;
            this.lblIOFBasTotal.Text = "0";
            // 
            // lblLiquido
            // 
            this.lblLiquido.AutoSize = true;
            this.lblLiquido.BackColor = System.Drawing.Color.ForestGreen;
            this.lblLiquido.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblLiquido.Location = new System.Drawing.Point(947, 511);
            this.lblLiquido.Name = "lblLiquido";
            this.lblLiquido.Size = new System.Drawing.Size(13, 15);
            this.lblLiquido.TabIndex = 33;
            this.lblLiquido.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Red;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(522, 485);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 15);
            this.label11.TabIndex = 34;
            this.label11.Text = "Total:";
            // 
            // lblTotalSaque
            // 
            this.lblTotalSaque.AutoSize = true;
            this.lblTotalSaque.BackColor = System.Drawing.Color.Red;
            this.lblTotalSaque.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTotalSaque.Location = new System.Drawing.Point(554, 485);
            this.lblTotalSaque.Name = "lblTotalSaque";
            this.lblTotalSaque.Size = new System.Drawing.Size(13, 15);
            this.lblTotalSaque.TabIndex = 35;
            this.lblTotalSaque.Text = "0";
            // 
            // dtpHJ
            // 
            this.dtpHJ.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHJ.Location = new System.Drawing.Point(40, 194);
            this.dtpHJ.Name = "dtpHJ";
            this.dtpHJ.Size = new System.Drawing.Size(141, 23);
            this.dtpHJ.TabIndex = 36;
            // 
            // dtpPrimSaq
            // 
            this.dtpPrimSaq.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPrimSaq.Location = new System.Drawing.Point(40, 238);
            this.dtpPrimSaq.Name = "dtpPrimSaq";
            this.dtpPrimSaq.Size = new System.Drawing.Size(141, 23);
            this.dtpPrimSaq.TabIndex = 38;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Location = new System.Drawing.Point(40, 220);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 15);
            this.label12.TabIndex = 37;
            this.label12.Text = "Data do primeiro saque:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(40, 150);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(141, 23);
            this.dateTimePicker1.TabIndex = 39;
            // 
            // lstJuros
            // 
            this.lstJuros.BackColor = System.Drawing.SystemColors.Info;
            this.lstJuros.FormattingEnabled = true;
            this.lstJuros.ItemHeight = 15;
            this.lstJuros.Location = new System.Drawing.Point(501, 96);
            this.lstJuros.Name = "lstJuros";
            this.lstJuros.Size = new System.Drawing.Size(89, 139);
            this.lstJuros.TabIndex = 42;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label14.Location = new System.Drawing.Point(501, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 20);
            this.label14.TabIndex = 40;
            this.label14.Text = "Juros";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Location = new System.Drawing.Point(620, 68);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 20);
            this.label15.TabIndex = 44;
            this.label15.Text = "IOF Básico";
            // 
            // lstIOFBas
            // 
            this.lstIOFBas.BackColor = System.Drawing.SystemColors.Info;
            this.lstIOFBas.FormattingEnabled = true;
            this.lstIOFBas.ItemHeight = 15;
            this.lstIOFBas.Location = new System.Drawing.Point(620, 96);
            this.lstIOFBas.Name = "lstIOFBas";
            this.lstIOFBas.Size = new System.Drawing.Size(89, 139);
            this.lstIOFBas.TabIndex = 46;
            // 
            // lstSaldoDev
            // 
            this.lstSaldoDev.BackColor = System.Drawing.SystemColors.Info;
            this.lstSaldoDev.FormattingEnabled = true;
            this.lstSaldoDev.ItemHeight = 15;
            this.lstSaldoDev.Location = new System.Drawing.Point(282, 335);
            this.lstSaldoDev.Name = "lstSaldoDev";
            this.lstSaldoDev.Size = new System.Drawing.Size(103, 139);
            this.lstSaldoDev.TabIndex = 50;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label16.Location = new System.Drawing.Point(282, 307);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(108, 20);
            this.label16.TabIndex = 49;
            this.label16.Text = "Saldo devedor";
            // 
            // lstAmortizado
            // 
            this.lstAmortizado.BackColor = System.Drawing.SystemColors.Info;
            this.lstAmortizado.FormattingEnabled = true;
            this.lstAmortizado.ItemHeight = 15;
            this.lstAmortizado.Location = new System.Drawing.Point(409, 335);
            this.lstAmortizado.Name = "lstAmortizado";
            this.lstAmortizado.Size = new System.Drawing.Size(89, 139);
            this.lstAmortizado.TabIndex = 52;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(409, 307);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 20);
            this.label13.TabIndex = 51;
            this.label13.Text = "Amortizado";
            // 
            // lstIOFtotal
            // 
            this.lstIOFtotal.BackColor = System.Drawing.SystemColors.Info;
            this.lstIOFtotal.FormattingEnabled = true;
            this.lstIOFtotal.ItemHeight = 15;
            this.lstIOFtotal.Location = new System.Drawing.Point(860, 96);
            this.lstIOFtotal.Name = "lstIOFtotal";
            this.lstIOFtotal.Size = new System.Drawing.Size(89, 139);
            this.lstIOFtotal.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(860, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 53;
            this.label3.Text = "IOF Total";
            // 
            // lblTotalAmo
            // 
            this.lblTotalAmo.AutoSize = true;
            this.lblTotalAmo.BackColor = System.Drawing.Color.Red;
            this.lblTotalAmo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTotalAmo.Location = new System.Drawing.Point(443, 485);
            this.lblTotalAmo.Name = "lblTotalAmo";
            this.lblTotalAmo.Size = new System.Drawing.Size(13, 15);
            this.lblTotalAmo.TabIndex = 56;
            this.lblTotalAmo.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Red;
            this.label19.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label19.Location = new System.Drawing.Point(411, 485);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 15);
            this.label19.TabIndex = 55;
            this.label19.Text = "Total:";
            // 
            // lblJurosTot
            // 
            this.lblJurosTot.AutoSize = true;
            this.lblJurosTot.BackColor = System.Drawing.Color.ForestGreen;
            this.lblJurosTot.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblJurosTot.Location = new System.Drawing.Point(536, 246);
            this.lblJurosTot.Name = "lblJurosTot";
            this.lblJurosTot.Size = new System.Drawing.Size(13, 15);
            this.lblJurosTot.TabIndex = 58;
            this.lblJurosTot.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.ForestGreen;
            this.label20.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label20.Location = new System.Drawing.Point(501, 246);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 15);
            this.label20.TabIndex = 57;
            this.label20.Text = "Total:";
            // 
            // lstIOFflat
            // 
            this.lstIOFflat.BackColor = System.Drawing.SystemColors.Info;
            this.lstIOFflat.FormattingEnabled = true;
            this.lstIOFflat.ItemHeight = 15;
            this.lstIOFflat.Location = new System.Drawing.Point(740, 96);
            this.lstIOFflat.Name = "lstIOFflat";
            this.lstIOFflat.Size = new System.Drawing.Size(89, 139);
            this.lstIOFflat.TabIndex = 60;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label17.Location = new System.Drawing.Point(740, 68);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 20);
            this.label17.TabIndex = 59;
            this.label17.Text = "IOF Flat";
            // 
            // lblTotalFlat
            // 
            this.lblTotalFlat.AutoSize = true;
            this.lblTotalFlat.BackColor = System.Drawing.Color.ForestGreen;
            this.lblTotalFlat.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTotalFlat.Location = new System.Drawing.Point(775, 244);
            this.lblTotalFlat.Name = "lblTotalFlat";
            this.lblTotalFlat.Size = new System.Drawing.Size(13, 15);
            this.lblTotalFlat.TabIndex = 62;
            this.lblTotalFlat.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.ForestGreen;
            this.label21.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label21.Location = new System.Drawing.Point(740, 244);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 15);
            this.label21.TabIndex = 61;
            this.label21.Text = "Total:";
            // 
            // lblIOF
            // 
            this.lblIOF.AutoSize = true;
            this.lblIOF.BackColor = System.Drawing.Color.ForestGreen;
            this.lblIOF.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblIOF.Location = new System.Drawing.Point(895, 244);
            this.lblIOF.Name = "lblIOF";
            this.lblIOF.Size = new System.Drawing.Size(13, 15);
            this.lblIOF.TabIndex = 64;
            this.lblIOF.Text = "0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.ForestGreen;
            this.label23.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label23.Location = new System.Drawing.Point(860, 244);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 15);
            this.label23.TabIndex = 63;
            this.label23.Text = "Total:";
            // 
            // frmForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Sienna;
            this.ClientSize = new System.Drawing.Size(1048, 578);
            this.Controls.Add(this.lblIOF);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.lblTotalFlat);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lstIOFflat);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblJurosTot);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblTotalAmo);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lstIOFtotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstAmortizado);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lstSaldoDev);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lstIOFBas);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lstJuros);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dtpPrimSaq);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dtpHJ);
            this.Controls.Add(this.lblTotalSaque);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblLiquido);
            this.Controls.Add(this.lblIOFBasTotal);
            this.Controls.Add(this.lblVPbruto);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lstVP);
            this.Controls.Add(this.lstDesagio);
            this.Controls.Add(this.lstDias);
            this.Controls.Add(this.lstSaqueAut);
            this.Controls.Add(this.lstData);
            this.Controls.Add(this.lstSaques);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTaxaDResult);
            this.Controls.Add(this.lblTaxaAResult);
            this.Controls.Add(this.txtTaxaAM);
            this.Controls.Add(this.txtSaldoHJ);
            this.Controls.Add(this.lblTaxaAD);
            this.Controls.Add(this.lblTaxaAA);
            this.Controls.Add(this.lblTaxaAM);
            this.Controls.Add(this.lblDataHJ);
            this.Controls.Add(this.lblDataNasc);
            this.Controls.Add(this.lblSaldoHJ);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmForm1";
            this.Text = "   ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSaldoHJ;
        private System.Windows.Forms.Label lblDataNasc;
        private System.Windows.Forms.Label lblDataHJ;
        private System.Windows.Forms.Label lblTaxaAD;
        private System.Windows.Forms.Label lblTaxaAA;
        private System.Windows.Forms.Label lblTaxaAM;
        private System.Windows.Forms.TextBox txtSaldoHJ;
        private System.Windows.Forms.TextBox txtTaxaAM;
        private System.Windows.Forms.Label lblTaxaAResult;
        private System.Windows.Forms.Label lblTaxaDResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.ListBox lstSaques;
        private System.Windows.Forms.ListBox lstData;
        private System.Windows.Forms.ListBox lstSaqueAut;
        private System.Windows.Forms.ListBox lstDias;
        private System.Windows.Forms.ListBox lstDesagio;
        private System.Windows.Forms.ListBox lstVP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblVPbruto;
        private System.Windows.Forms.Label lblIOFBasTotal;
        private System.Windows.Forms.Label lblLiquido;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblTotalSaque;
        private System.Windows.Forms.DateTimePicker dtpHJ;
        private System.Windows.Forms.DateTimePicker dtpPrimSaq;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ListBox lstJuros;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox lstIOFBas;
        private System.Windows.Forms.ListBox lstSaldoDev;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ListBox lstAmortizado;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox lstIOFtotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalAmo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblJurosTot;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ListBox lstIOFflat;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblTotalFlat;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblIOF;
        private System.Windows.Forms.Label label23;
    }
}

