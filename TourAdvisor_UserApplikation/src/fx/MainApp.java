package fx;

import fx.view.MainFormController;
import javafx.application.Application;
import javafx.embed.swing.SwingNode;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.BorderPane;
import javafx.stage.Stage;

public class MainApp extends Application {

	private Stage primaryStage; 
    private AnchorPane samplesLayout;
    /**
     * The data as an observable list of Persons.
     */
     
    // Reference to the main application.
    private MainApp mainApp;
    
    /**
     * Constructor
     */
    public MainApp() {
    }
    

    
	@Override
	public void start(Stage primaryStage) throws Exception {
		this.primaryStage = primaryStage;
        this.primaryStage.setTitle("JNI FX Employee");
        initRootLayout();
	}
 	
	/**
	 * Initializes the root layout.
	 * @throws Exception when something went wrong
	 */
    public void initRootLayout() throws Exception {
        // Load root layout from fxml file.
        FXMLLoader loader = new FXMLLoader();
        loader.setLocation(MainApp.class.getResource("view/MainForm.fxml"));
        //samplesLayout = (BorderPane) loader.load();
        // Give the controller access to the main app.
        MainFormController controller = loader.getController();
        controller.setMainApp(this);
        
        
        BorderPane bp = new BorderPane();
        bp.setPrefWidth(600);
        bp.setPrefHeight(400);

		final SwingNode sn = new SwingNode();		      
        
        bp.setCenter(sn);
   
        // Show the scene containing the root layout.
        Scene scene = new Scene(samplesLayout);
        
        primaryStage.setScene(new Scene(bp));
        primaryStage.show();
    }        
    
    /**
     * Returns the main stage.
     * @return primaryStage
     */
    public Stage getPrimaryStage() {
        return primaryStage;
    }
    
    /**
     * defines what should happens when the stage gets closed
     * e.g. save data, logout, etc.
     */
    @Override
    public void stop(){
        System.out.println("Stage is closing");
    }

	public static void main(String[] args) {
		launch(args); 
	}
	
}
