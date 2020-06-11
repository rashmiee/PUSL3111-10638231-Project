import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:iptprogramnsbm/welcome_screen.dart';

class AdminStudentsSection extends StatefulWidget {
  AdminStudentsSection({this.ipAddressText});
  final String ipAddressText;

  @override
  _AdminStudentsSectionState createState() => _AdminStudentsSectionState();
}

class _AdminStudentsSectionState extends State<AdminStudentsSection> {
  int _selectedIndex = 0;
  static const TextStyle optionStyle =
      TextStyle(fontSize: 30, fontWeight: FontWeight.bold);
  static const List<Widget> _widgetOptions = <Widget>[
    Text(
      'All Students list comes here',
      style: optionStyle,
    ),
    Text(
      'Un-approved Students name list comes here',
      style: optionStyle,
    ),
  ];

  void _onItemTapped(int index) {
    setState(() {
      _selectedIndex = index;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('BottomNavigationBar Sample'),
      ),
      body: Center(
        child: _widgetOptions.elementAt(_selectedIndex),
      ),
      bottomNavigationBar: BottomNavigationBar(
        items: const <BottomNavigationBarItem>[
          BottomNavigationBarItem(
            icon: Icon(Icons.list),
            title: Text('View All Students'),
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.playlist_add),
            title: Text('un-approved Students'),
          ),
        ],
        currentIndex: _selectedIndex,
        selectedItemColor: Colors.amber[800],
        onTap: _onItemTapped,
      ),
    );
  }
}
