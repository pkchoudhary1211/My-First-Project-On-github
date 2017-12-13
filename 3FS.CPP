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

void writerecord(){

	file.open("dk.txt",ios::app);

	if(!file){
		cout << "Cannot open the file in append mode";
		getch();
		exit(0);
	}

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

	strcpy(s.buffer,s.name);
	strcat(s.buffer,"|");
	strcat(s.buffer,s.usn);
	strcat(s.buffer,"|");
	strcat(s.buffer,s.age);
	strcat(s.buffer,"|");
	strcat(s.buffer,s.sem);
	strcat(s.buffer,"|");
	strcat(s.buffer,s.branch);

     //	int count = strlen(s.buffer);

  //	for(int k=0; k<45-count; k++ ){
    //		strcat(s.buffer,"!");
       //	}
      ///	strcat(s.buffer,"\n");

	file << s.buffer;
	file.close();
}

void search(){
	char usn[10];
      //	char extra[45];

	file.open("dk.txt",ios::in);

	if(!file){
		cout << "Cannot open the file ";
		getch();
		exit(0);
	}

	cout<<"\nEnter the username you want to search : ";
	cin >> usn;

	while(!file.eof()){
		file.getline(s.name,10,'|');
		file.getline(s.usn,10,'|');
		file.getline(s.age,5,'|');
		file.getline(s.sem,5,'|');
		file.getline(s.branch,5,'\n');
      //	file.getline(extra,45,'\n');

		if(strcmp(s.usn,usn) == 0){
			cout << "\nRecord Found";
			cout << "\n" << s.name <<"\t\t" << s.usn <<"\t\t" << s.age <<"\t\t" << s.sem <<"\t\t" << s.branch ;
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
	int i;
	char extra[45];

	file.open("dk.txt",ios::in);

	if(!file){
		cout << "Cannot open the file";
		getch();
		exit(0);
	}

	i = 0;

	cout << "\n\n NAME \t\t USN \t\t AGE \t\t SEM \t\t BRANCH \n";
	cout << "---- \t\t ---- \t\t ---- \t\t ---- \t\t ---- \n";

	while(!file.eof()){
		file.getline(s.name,10,'|');
		file.getline(s.usn,10,'|');
		file.getline(s.age,5,'|');
		file.getline(s.sem,5,'|');
		file.getline(s.branch,5,'\n');
	    //	file.getline(extra,45,'\n');

		cout << "\n" << s.name <<"\t\t " << s.usn <<"\t\t " << s.age <<"\t\t " << s.sem <<"\t\t " << s.branch ;
		i++;
	}
	file.close();
	getch();
}

void modify()
{
	char usn[10];
	char buffer[45];
       //	char extra[45];
	int i;
	int j;
	Student s[20];

	file.open("dk.txt",ios::in);

	if(!file){
		cout << "Cannot open the file";
		getch();
		exit(0);
	}

	cout <<"\nEnter the username you want to modify : ";
	cin >> usn;
	cout << "\n";

	i = 0;
	while(!file.eof()){
		file.getline(s[i].name,10,'|');
		file.getline(s[i].usn,10,'|');
		file.getline(s[i].age,5,'|');
		file.getline(s[i].sem,5,'|');
		file.getline(s[i].branch,5,'\n');
	 //	file.getline(extra,45,'\n');

		i++;
	}

	i--;

	for(j=0; j<i; j++){
		if(strcmp(usn,s[j].usn) == 0){
			cout << "\n The old values of record with username " << usn << "are : ";
			cout<< "\nName : " << s[j].name;
			cout<< "\nUsername : " << s[j].usn;
			cout<< "\nAge : " << s[j].age;
			cout<< "\nSem : " << s[j].sem;
			cout<< "\nBranch : " << s[j].branch;

			cout << "/n/nEnter the new values : ";
			cout << "\nName : ";
			cin >> s[j].name;
			cout << "\nUsername : ";
			cin >> s[j].usn;
			cout << "\nAge : ";
			cin >> s[j].age;
			cout << "\nSem : ";
			cin >> s[j].sem;
			cout << "\nBranch : ";
			cin >> s[j].branch;

			break;
		}
	}

	if(j == 1){
		cout << "\nThe record with username " << usn << "is not present";
		getch();
		return;
	}

	file.close();

	file.open("dk.txt",ios::out);

	if(!file){
		cout << "Cannot open the file";
		getch();
		exit(0);
	}

	for(j=0; j<i; j++){

		strcpy(buffer,s[j].name);
		strcat(buffer,"|");
		strcat(buffer,s[j].usn);
		strcat(buffer,"|");
		strcat(buffer,s[j].age);
		strcat(buffer,"|");
		strcat(buffer,s[j].sem);
		strcat(buffer,"|");
		strcat(buffer,s[j].branch);

	       //	int count = strlen(buffer);

	       //	for(int k=0; k<45-count; k++ ){
	       //		strcat(buffer,"!");
		//}
	       //	strcat(buffer,"\n");

		file << buffer;
	}
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
