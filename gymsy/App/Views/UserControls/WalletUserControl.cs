using gymsy.Context;
using gymsy.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio.TwiML.Voice;
using gymsy.Modelos;
//using Pay = gymsy.Models.Pago;
using gymsy.App.Views.Interfaces;
using PdfSharp.Pdf;
using PdfSharp;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using Application = System.Windows.Forms.Application;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using PdfSharp.Drawing;
using System.Drawing.Imaging;
using System.Net.NetworkInformation;
using gymsy.Properties;
using gymsy.Models;

namespace gymsy.UserControls
{
    public partial class WalletUserControl : UserControl, IWalletView
    {

        private NuevoGymsyContext gymsydb = ViejoGymsyContext.GymsyContextDB;
        private IEnumerable<Pago> PaysList;
        private Pago PayActive;
        private NuevoGymsyContext dbContext;

        public WalletUserControl()
        {
            InitializeComponent();
            InitializeData();
            InitializeGridTransactions();
            this.dbContext = ViejoGymsyContext.GymsyContextDB;
        }

        private void InitializeData()
        {
         /*   if (AppState.person.Wallets.Count > 0)
            {
                TbAmount.Text = $"$ {AppState.person.Wallets.First().Retirable}";
                TbTotalAmount.Text = $"$ {AppState.person.Wallets.First().Total}";
            }

            this.PaysList = AppState.person.PayDestinatarios.ToArray()
                    .Concat(AppState.person.PayRemitentes.ToArray());


            Dictionary<string, string> diccionario = new Dictionary<string, string>();

            AppState.persons.ForEach(per =>
            {
                if (per.IdRol != 3 && per.IdUsuario != AppState.person.IdUsuario)
                {
                    diccionario.Add(per.IdUsuario.ToString(), per.Nombre);
                }
            });

            comboBoxInstructors.DataSource = new BindingSource(diccionario, null);
            comboBoxInstructors.DisplayMember = "Value";
            comboBoxInstructors.ValueMember = "Key";*/
        }

        private void InitializeGridTransactions()
        {/*
            // Concatenar pagos realizados y entrantes
            if (PaysList.Count() > 0)
            {

                dataGridTransactions.Visible = true;
                PanelMsg.Visible = false;

                foreach (Pay pay in PaysList)
                {
                    TimeSpan diferencia = (DateTime.Now - pay.FechaCreacion);
                    String formart = $"Hace {diferencia.Days} dias";
                    int destinoId = pay.RemitenteId == AppState.person.IdPerson ? pay.DestinatarioId : pay.RemitenteId;

                    dataGridTransactions.Rows.Add(
                        pay.IdPago,
                        formart,
                        pay.IdTipoPagoNavigation.Nombre,
                        $"$ {pay.Monto}",
                        $"Destino: {destinoId}"
                    );
                }

                dataGridTransactions.Refresh();
            }
            else
            {
                PanelMsg.Visible = true;
            }
            */
        }

        private void AddTransaction(Pago pay)
        {
            /*
            TimeSpan diferencia = (DateTime.Now - pay.FechaCreacion);
            String formart = $"Hace {diferencia.Days} dias";
            //int destinoId = pay.RemitenteId == AppState.person.IdPerson ? pay.DestinatarioId : pay.RemitenteId;

            dataGridTransactions.Rows.Add(
                pay.IdPago,
                formart,
                pay.IdTipoPagoNavigation.Nombre,
                $"$ {pay.Monto}",
                $"Origen: {pay.IdUsuario}"
            );

            dataGridTransactions.Refresh();
            */
        }

        private void TextBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.TextBoxOnlyNumbersWithDecimal(sender, e);
        }

        private void BtnNewTransaction_Click(object sender, EventArgs e)
        {/*
            try
            {
              
                // Ocultar errores anteriores
                labelTransactionError.Visible = false;

                // Validamos dinero disponible en su billetera
                if ((Double.Parse(TbAmountTran.Text) > 0) &&
                    AppState.person.Wallets.First().Retirable <= Double.Parse(TbAmountTran.Text)
                    )
                {
                    labelTransactionError.Text = "Fondos insuficientes";
                    labelTransactionError.Visible = true;
                    return;
                }

                // Validamos instructor
                if (!Utility.IsValidComboBox(comboBoxInstructors, labelTransactionError))
                {
                    labelTransactionError.Text = "Necesitas seleccionar 1 instructor";
                    return;
                }

                // se hace la transaccion
                Pay ModelPay = new Pay();
                ModelPay.FechaCreacion = DateTime.Now;
                ModelPay.Monto =(decimal) double.Parse(TbAmountTran.Text);
                ModelPay.IdUsuario = AppState.person.IdUsuario;
                ModelPay.IdTipoPago = 1;
                ModelPay.InactivoPago = false;
               


                // Resta monto de billetera
                Wallet WalletModel = AppState.person.Wallets.First();
                WalletModel.Retirable -= double.Parse(TbAmountTran.Text);

                this.gymsydb.Pagos.Add(ModelPay);
                var PaysResponse = this.gymsydb.SaveChanges();

                if (PaysResponse != 0)
                {
                    this.gymsydb.Wallets.Update(WalletModel);
                    this.gymsydb.SaveChanges();

                    var WalletDestinarioFound = this.gymsydb.Wallets.Where(wallet => wallet.IdPerson == int.Parse(comboBoxInstructors.SelectedValue.ToString())).First();
                    WalletDestinarioFound.Retirable += double.Parse(TbAmountTran.Text);
                    this.gymsydb.Wallets.Update(WalletDestinarioFound);
                    this.gymsydb.SaveChanges();

                    // Update state
                    this.PaysList.ToList().Add(ModelPay);

                    TbAmount.Text = $"$ {WalletModel.Retirable}";
                    AddTransaction(ModelPay);

                    PanelInvoiceWallet.Visible = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                labelTransactionError.Text = "Error Inesperado";
                labelTransactionError.Visible = true;
            }*/
        }

        private void BtnNewWithdraw_Click(object sender, EventArgs e)
        {/*
            // Ocultar errores anteriores
            labelErrorWithdraw.Visible = false;

            try
            {

                // Validamos dinero disponible en su billetera
                if ((Double.Parse(TBWithdraw.Text) > 0) &&
                   AppState.person.Wallets.First().Retirable <= Double.Parse(TBWithdraw.Text)
                   )
                {
                    labelErrorWithdraw.Text = "Fondos insuficientes";
                    labelErrorWithdraw.Visible = true;
                    return;
                }

                Wallet WalletUpdate = AppState.person.Wallets.First();
                WalletUpdate.Retirable -= Double.Parse(TBWithdraw.Text);

                this.gymsydb.Wallets.Update(WalletUpdate);
                var WalletResponse = this.gymsydb.SaveChanges();

                if (WalletUpdate.Retirable != 0)
                {
                    TbAmount.Text = $"$ {WalletUpdate.Retirable}";
                    PanelInvoiceWallet.Visible = true;
                }
            }
            catch
            {
                labelErrorWithdraw.Text = "Error Inesperado";
                labelErrorWithdraw.Visible = true;
            }

            PanelInvoiceWallet.Visible = true;
        */}

        private bool CheckAvailableMoney(float money = 0)
        {
            return float.Parse(TbAmount.Text) >= money;
        }

        private void BtnCloseInvoice_Click(object sender, EventArgs e)
        {
            PanelInvoiceWallet.Visible = false;
        }

        private void dataGridTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {

                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;


                int IdPaySelected = int.Parse(dataGridTransactions.Rows[rowIndex].Cells["ID"].Value.ToString());

                var PaySelected = this.dbContext.Pagos
                                .Where(pay => pay.IdPago == IdPaySelected)
                                .First();

                // Navigate to training history
                if (PaySelected != null)
                {
                    this.PayActive = PaySelected;
                    PanelInvoiceWallet.Visible = true;
                }
            } 
        }

        private void BtnDownloadPDF_Click(object sender, EventArgs e)
        {
            string rutaArchivo  = utilities.GenarateComprobante.GeneratePdfComprobante(this.PayActive);
            MessageBox.Show("Archivo HTML generado exitosamente en: " + rutaArchivo);
            PanelInvoiceWallet.Visible = false;
        }




        private void BtnSendWhatsapp_Click(object sender, EventArgs e)
        {
            /*

            if (!utilities.Verify.IsConnectedToNetwork())
            {
                MessageBox.Show("Necesitas conexion a internet");
                return;
            }

            try
            {
                string rutaArchivo = utilities.GenarateComprobante.GeneratePdfComprobante(this.PayActive);
                string htmlContent = File.ReadAllText(rutaArchivo);


                // Crear un formulario y agregar un control WebBrowser
                using (var form = new Form())
                using (var browser = new WebBrowser())
                {
                    form.Controls.Add(browser);
                    form.Size = new System.Drawing.Size(800, 600);

                    // Navegar al contenido HTML
                    browser.Navigate("about:blank");
                    browser.Document.OpenNew(true);
                    browser.Document.Write(htmlContent);
                    browser.Refresh();

            
                    int captureWidth = 1000; 
                    int captureHeight = 800; 

                    // Capturar una captura de pantalla del control WebBrowser
                    using (Bitmap bitmap = new Bitmap(captureWidth, captureHeight))
                    {
                        browser.DrawToBitmap(bitmap, new Rectangle(0, 0, captureWidth, captureHeight));

                        // Genera un nombre de archivo único usando un GUID y la fecha/hora actual
                        string uniqueFileName = Guid.NewGuid().ToString() + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".png";

                        // Ruta completa para guardar la imagen en la carpeta
                        string destinationPath = Path.Combine(AppState.pathDestinationFolder, uniqueFileName);

                        // Guardar la imagen en un archivo (opcional)
                        bitmap.Save(destinationPath, System.Drawing.Imaging.ImageFormat.Png);

                        // Configura tu cuenta de Cloudinary
                        Account account = new Account(
                            Resources.accountNameCloudinary,
                            Resources.idCloudinary,
                            Resources.tokenCloudinary
                        );

                        Cloudinary cloudinary = new Cloudinary(account);

                        // Sube una imagen
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(destinationPath),
                        };

                        var uploadResult = cloudinary.Upload(uploadParams);

                        // El resultado contiene la URL de la imagen almacenada en Cloudinary
                        string imageUrl = uploadResult.Uri.ToString();

                        utilities.TwilioMSG.SendMessageComprobante(imageUrl);
              
                        File.Delete(destinationPath);
                        File.Delete(rutaArchivo);
                    }
                }
                    

            }
            catch
            {
                MessageBox.Show("Necesitas conexion a internet");
            }
            finally
            {
                PanelInvoiceWallet.Visible = false;
            }
            */
        }


 
    }
}
