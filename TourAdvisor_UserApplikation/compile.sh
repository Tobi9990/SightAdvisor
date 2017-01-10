#!/bin/bash
 if [ -d ./bin ]; then
   rm -fr ./bin   # clear in a brute force manner
fi
mkdir ./bin

javac -d bin -sourcepath src src/fx/data/ConnectionFactory.java -classpath "./Driver/ojdbc14.jar" src/fx/data/ConnectionFactory.java
echo "Class File ConnectionFactory created"

javac -d bin -sourcepath src src/fx/view/MainFormController.java -classpath "/usr/java/jdk1.8.0_73/jre/lib/ext/jfxrt.jar" src/fx/view/MainFormController.java
echo "Class File MainFormController created"

cp ./src/fx/view/application.css ./bin/fx/view/application.css
echo "Css File Application copied to bin Folder"

cp ./src/fx/view/MainForm.fxml ./bin/fx/view/MainForm.fxml
echo "Fxml File MainForm copied to bin Folder"

cp ./src/fx/view/Login.fxml ./bin/fx/view/Login.fxml
echo "Fxml File Login copied to bin Folder"

javac -d bin -sourcepath src src/fx/MainApp.java -classpath "/usr/java/jdk1.8.0_73/jre/lib/ext/jfxrt.jar" src/fx/MainApp.java
echo "Class File MainApp created"

cd ./bin

echo "MainApp starting..."
java fx.MainApp
echo "MainApp closed"



