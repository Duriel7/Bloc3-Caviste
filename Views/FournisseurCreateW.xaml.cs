using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Bloc3_Caviste.Views
{
    public partial class FournisseurCreate : Window
    {
        public FournisseurCreate()
        {
            InitializeComponent();
        }

        #region Window Controls
        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
        #endregion

        #region Placeholder Text Management
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Tag != null)
            {
                if (textBox.Text == textBox.Tag.ToString())
                {
                    textBox.Text = "";
                    textBox.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
                    textBox.FontWeight = FontWeights.Normal;
                }
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Tag != null)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = textBox.Tag.ToString();
                    textBox.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9CA3AF"));
                    textBox.FontWeight = FontWeights.Light;
                }
            }
        }
        #endregion

        #region Form Actions
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Validation des champs
            if (IsFormValid())
            {
                // Création de l'objet fournisseur
                var fournisseur = CreateFournisseurFromForm();
                
                // TODO: Sauvegarder en base de données
                // await _fournisseurService.CreateAsync(fournisseur);

                MessageBox.Show("✅ Fournisseur créé avec succès!", "Succès", 
                              MessageBoxButton.OK, MessageBoxImage.Information);
                
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("⚠️ Veuillez remplir tous les champs obligatoires.", "Validation", 
                              MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("❓ Êtes-vous sûr de vouloir annuler?\nToutes les données saisies seront perdues.", 
                                       "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            if (result == MessageBoxResult.Yes)
            {
                DialogResult = false;
                Close();
            }
        }
        #endregion

        #region Validation & Data Processing
        private bool IsFormValid()
        {
            return !IsPlaceholder(EntrepriseTextBox) &&
                   !IsPlaceholder(ContactTextBox) &&
                   !IsPlaceholder(EmailTextBox) &&
                   !IsPlaceholder(TelephoneTextBox) &&
                   !IsPlaceholder(AdresseTextBox) &&
                   !IsPlaceholder(VilleTextBox);
        }

        private bool IsPlaceholder(TextBox textBox)
        {
            return string.IsNullOrWhiteSpace(textBox.Text) || 
                   textBox.Text == textBox.Tag?.ToString();
        }

        private object CreateFournisseurFromForm()
        {
            return new
            {
                Entreprise = EntrepriseTextBox.Text,
                Contact = ContactTextBox.Text,
                Email = EmailTextBox.Text,
                Telephone = TelephoneTextBox.Text,
                Adresse = AdresseTextBox.Text,
                Ville = VilleTextBox.Text,
                DateCreation = System.DateTime.Now
            };
        }
        #endregion
    }
}
