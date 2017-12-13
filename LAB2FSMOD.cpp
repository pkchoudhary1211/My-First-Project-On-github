#include<stdlib.h>
#include<conio.h>
#include<iostream.h>
#include<fstream.h>
#include<string.h>

class Student{
	public:
			char name[10];
			char age[5];
			char usn[10];
			char sem[5];
			char branch[5];
			char buffer[45];
};

fstream file;
Student s;

void checkIfValidFile(){
	if(!file){
		cout << "Cannot open the file in append mode";
		getch();
		exit(1);
	}
}

void enterDetail(){
	cout << "\nEnter the student name : ";
	cin >> s.name;
	cout << "\nEnter the student usn : ";
	cin >> s.usn;
	cout << "\nEnter the student age : ";
	cin >> s.age;
	cout << "\nEnter the sem : ";
	cin >> s.sem;
	cout << "\nEnter the branch : ";
	cin >> s.branch;
}

void copyDataToBuffer(){
	strcpy(s.buffer,s.name);
	strcat(s.buffer,"|");
	strcat(s.buffer,s.usn);
	strcat(s.buffer,"|");
	strcat(s.buffer,s.age);
	strcat(s.buffer,"|");
	strcat(s.buffer,s.sem);
	strcat(s.buffer,"|");
	strcat(s.buffer,s.branch);
	
	int count = strlen(s.buffer);
	
	for(int k=0; k<45-count; k++ ){
		strcat(s.buffer,"!");
	}
	strcat(s.buffer,"\n");
	
	file << s.buffer;
	
}

void getDataFromFile(){
	char extra[45];

	file.getline(s.name,10,'|');
	file.getline(s.usn,10,'|');
	file.getline(s.age,5,'|');
	file.getline(s.sem,5,'|');
	file.getline(s.branch,5,'!');
	file.getline(extra,45,'\n');}

void displayTableHeader(){
	cout << "\n\n NAME \t\t USN \t\t AGE \t\t SEM \t\t BRANCH \n";
	cout << "---- \t\t ---- \t\t ---- \t\t ---- \t\t ---- \n";	
}

void displayTableRow(){
	cout << "\n"<<s.name <<"\t"<< s.usn <<"\t"<< s.age <<"\t\t"<< s.sem<<"\t\t"<< s.branch ;  
}

void writerecord(){
	
	file.open("Student.txt",ios::app);
	
	checkIfValidFile();
	enterDetail();
	copyDataToBuffer();
	file.close();
}

void search(){
	char usn[10];
	
	file.open("Student.txt",ios::in);
	checkIfValidFile();
	
	cout<<"\nEnter the username you want to search : ";
	cin >> usn;
	
	while(!file.eof()){
		getDataFromFile();
		
		if(strcmp(s.usn,usn) == 0){
			displayTableHeader();
			displayTableRow();
			file.close();
			getch();
			return; 
		}
	}
	cout << "\nRecord not found!!";
	file.close();
	getch();
}

void displayfile(){	
	file.open("Student.txt",ios::in);
	
	checkIfValidFile();	
	displayTableHeader();

	while(!file.eof()){
		getDataFromFile();
		displayTableRow();
	}
	file.close();
	getch();
}

void modify(){
	char usn[10];
	int i;
	int j;
	Student std[20];
	
	file.open("Student.txt",ios::in);
	checkIfValidFile();
	
	cout <<"\nEnter the username : ";
	cin >> usn;
	cout << "\n";
	
	i = 0;
	
	while(!file.eof()){
		getDataFromFile();
		std[i] = s;
		i++;	
	}

	i--;
	
	for(j=0; j<i; j++){
		if(strcmp(usn,std[j].usn) == 0){
			cout << "\nThe old values of record with username " << usn << "are : ";
			displayTableHeader();
			s = std[j];
			displayTableRow();
			cout << "\n\nEnter the new values : ";
			enterDetail();
			std[j] = s;
			break;
		}
	}
	
	if(j == i){
		cout << "\nThe record with username " << usn << "is not present";
		getch();
		return;
	}
	
	file.close();
	file.open("Student.txt",ios::out);
	checkIfValidFile();

	for(j=0; j<i; j++){
		s = std[j];
		copyDataToBuffer();
	}
	file.close();
}

void main(){
	
	int ch;
	
	while(1){
		
		clrscr();
		
		cout << "\n1.Write to the file.";
		cout << "\n2.Display the file.";
		cout << "\n3.Modify the file.";
		cout << "\n4.Search the file.";
		cout << "\n5.Exit";
		cout << "\nEnter your choice : ";
		cin >> ch;
		
		switch(ch){
			
			case 1 : 
					writerecord();
					break;
			case 2 : 
					displayfile();
					break;
			case 3 : 
					modify();
					break;
			case 4 : 
					search();
					break;
			case 5 : 
					exit(0);
			default:
					cout << "\nInvalid Choice!!";
					
		}
		
	}
}

