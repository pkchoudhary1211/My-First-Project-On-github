#include<conio.h>
#include<stdio.h>
#include<stdlib.h>
#include<iostream.h>
#include<string.h>
#include<iomanip.h>
#include<fstream.h>
class student{
	public: char name[15],usn[15],age[5],sem[5],brh[5],id[5];
};
void wc()
{
	int k,n;
	fstream file;
	student s;
	file.open("pk.txt",ios::app);
       if(!file)
       {
		cout<<"Enable to open file";
		getch();
		exit(0);
       }
       cout<<"\n Enter Number  of records" ;
       cin>>n;
       for(k=0;k<n;k++)
       {
		cout<<"Enter Name :-";
		cin>>s.name;
		cout<<"Enter USN :-";
		cin>>s.usn;
		cout<<"Entert Age" ;
		cin>>s.age;
		cout<<"Enter Sem";
		cin>>s.sem;
		cout<<"Enter Branch:";
		cin>>s.brh;
		file<<"\n"<<k<<"|"<<s.name<<"|"<<s.usn<<"|"<<s.age<<"|"<<s.sem<<"|"<<s.brh;


       }
	   file.close();

}
void show()
{
	student s;
	fstream file;
	int i=0;
	char rrn[10];
	file.open("pk.txt",ios::in);
	if(!file)
	{
		cout<<"anable to open file";
		getch();
		exit(0);
	}

	cout<<"\nrrn\tname\tusn\tage\tsem\tbranch";
	while(!file.eof())
	{

	       file.getline(s.id,5,'|');
	       file.getline(s.name,15,'|');
	      // cout<<s.name;
	       file.getline(s.usn,15,'|');
	       file.getline(s.age,5,'|');
	       file.getline(s.sem,5,'|');
	       file.getline(s.brh,5,'\n');
	       cout<<"\n"<<i<<"\t"<<s.name<<"\t"<<s.usn<<"\t"<<s.age<<"\t"<<s.sem<<"\t"<<s.brh<<"\n";
	i++;
	}
	file.close();
}
void search()
{
       //	char rrn[100],rrn1[10][15];
	char rrn[100];
	int i=0,flag=0;
	student stu;
	fstream file;
	cout<<"\n Enter Your Name OR USN to be search :";
	cin>>rrn;
		file.open("pk.txt",ios::in);
	if(!file)
	{
		cout<<"anable to open file";
		getch();
		exit(0);
	}
		cout<<"\nrrn\tname\tusn\tage\tsem\tbranch";

      //	cout<<"\nrrn\t\tname\t\tusn\t\tage\t\tsem\t\tbranch";
	while(!file.eof())
	{
	      // file.getline(rrn[i],4,'|');
	       file.getline(stu.id,5,'|');
	       file.getline(stu.name,15,'|');
	       file.getline(stu.usn,15,'|');
	       file.getline(stu.age,5,'|');
	       file.getline(stu.sem,5,'|');
	       file.getline(stu.brh,5,'\n');

	       if(strcmp(rrn,stu.name)==0 || strcmp(rrn,stu.usn)==0)
	       {
	       flag=1;

		    cout<<"\n"<<i<<"\t"<<stu.name<<"\t"<<stu.usn<<"\t"<<stu.age<<"\t"<<stu.sem<<"\t"<<stu.brh<<"\n";

	       }
		i++;
	}
	file.close();
	if(flag==0)
	{
	cout<<"\nRecord Ela Re!!!";
	}

}
void main()
{
	clrscr();
	int ch;
	while(1)
	{
	cout<<"\n1 ADD new DATA \n2 Show all the DATA\n3 Find DATA\n0 Exit\n Enter Your Choice";
	cin>>ch;
	switch(ch)
	{
	 case 1:
		wc();
		break;
	 case 2:
		show();
		break;
	 case 3:
		search();
		break;
	 case 0:
	 exit(0);
	 default:
	 cout<<"shi input de re";
	 break;
	}
	}
	getch();
}