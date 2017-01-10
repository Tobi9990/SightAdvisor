package fx.data;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

import oracle.jdbc.OracleDriver;


/**
 * This is the class Connection Factory for creating Oracle connection.
 * 
 * @author Tobias
 *
 */
public class ConnectionFactory {

	private static ConnectionFactory cf = new ConnectionFactory();
	private static final String PROPERTY_CMD = System.getProperty("user.dir");
	private static final String PROPERTY_HOME = System.getProperty("user.home");
	private static final String PROPERTY_STATIC = System.getProperty("user");
	/**
	 * KEY_DRIVER is the driver for the Database
	 */
	private static final String KEY_DRIVER = "dbDriver";
	/**
	 * KEY_URL is the url for the Database
	 */
	private static final String KEY_URL = "dbUrl";
	/**
	 * KEY_USER is the user for the Database
	 */
	private static final String KEY_USER = "dbUser";
	/**
	 * KEY_PWD is the password for the Database
	 */
	private static final String KEY_PWD = "dbPwd";
	
	/**
	 * Default driver is the Oracle driver
	 */
	private static final String DRIVER = "oracle.jdbc.OracleDriver";
	// Intern IP-Address
	private static final String INTERNAL_URL = "jdbc:oracle:thin:@aphrodite4:1521:ora11g";
	// Extern IP-Address
	private static final String EXTERNAL_URL = "jdbc:oracle:thin:@212.152.179.117:1521:ora11g";
	private static final String USER = "d5a04";
	private static final String PWD = "d5a";
	
	private static Connection con;
	private static Statement stmt;
	private static ResultSet rs;

	private ConnectionFactory() {
		OracleDriver driver = new OracleDriver(); 
		try {
			DriverManager.registerDriver(driver);
		} catch (SQLException e) {
			e.printStackTrace();
		}

		//Class.forName(DRIVER);
		System.out.println("Driver " + DRIVER + " sucessfully loaded");
	}	
	
	public static Connection connect(String url, String user, String pwd) throws SQLException, ClassNotFoundException {
		Class.forName(DRIVER);
		con = DriverManager.getConnection(url, user, pwd);
		return DriverManager.getConnection(url, user, pwd);
	}
	
	public static Connection connectInternal() throws SQLException, ClassNotFoundException  {
		Class.forName(DRIVER);
		con = DriverManager.getConnection(INTERNAL_URL, USER, PWD);
		return DriverManager.getConnection(INTERNAL_URL, USER, PWD);
	}
	
	public static Connection connectExternal() throws SQLException, ClassNotFoundException  {
		Class.forName(DRIVER);
		con = DriverManager.getConnection(EXTERNAL_URL, USER, PWD);
		return DriverManager.getConnection(EXTERNAL_URL, USER, PWD);
	}
	
	public static Statement createStatement() throws SQLException {
		Statement stmt = con.createStatement();
		return stmt;
	}

	public static boolean closeResultSet(ResultSet rs) {
		try {
			rs.close();
			return true;
		} catch (Exception ignored) {
			return false;
		} 
	}

	public static void closeSatement(Statement stmt) throws SQLException {
		stmt.close();
	}

	public static void closeConnection(Connection con) throws SQLException {
		con.close();
		System.out.println("Sucessfully disconnected from Database!");
	}
}
