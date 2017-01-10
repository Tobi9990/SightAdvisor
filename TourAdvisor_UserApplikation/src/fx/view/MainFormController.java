/**
 * 
 */
package fx.view;

import fx.MainApp;
import javafx.embed.swing.SwingNode;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.Label;

/**
 * @author pupil
 *
 */
public class MainFormController {

	public MainFormController() {
		initialize();
	}

	// Main Application
	private MainApp mainApplication;

	/**
	 * Set the main Application
	 * @param mainApp Class
	 */
	public void setMainApp(MainApp mainApp) {
		this.mainApplication = mainApp;
	}

	@FXML
	private Button btnRegister;
	@FXML
	private Button btnLogin;
	@FXML
	private Button btnQuit;

	private void initialize() {	
		getBtnRegister();
		getBtnLogin();
		getBtnQuit() ;
	}

	private Button getBtnRegister() {
		if (btnRegister == null) {
			btnRegister = new Button();
		}
		return btnRegister;
	}
	
	private Button getBtnLogin() {
		if (btnLogin == null) {
			btnLogin = new Button();
		}
		return btnLogin;
	}
	
	private Button getBtnQuit() {
		if (btnQuit == null) {
			btnQuit = new Button();
		}
		return btnQuit;
	}

	private void btnRegisterOnClick() {
		
	}
	
	private void btnLoginOnClick() {
			
	}

	private void btnQuitOnClick() {
		
	}
}
