import 'package:flutter/material.dart';

class Students {
  final String studentID;
  final String studentName;
  final String studentCourse;
  final String studentUsername;
  final String studentPassword;
  final String studentEmail;

  Students(
      {this.studentID,
      this.studentCourse,
      this.studentEmail,
      this.studentName,
      this.studentPassword,
      this.studentUsername});

  factory Students.fromJson(Map<String, dynamic> json) {
    return Students(
      studentID: json['STUDENT_ID'],
      studentCourse: json['STUDENT_COURSE'],
      studentEmail: json['STUDENT_EMAIL'],
      studentName: json['STUDENT_NAME'],
      studentPassword: json['STUDENT_PASSWORD'],
      studentUsername: json['STUDENT_USERNAME'],
    );
  }
}
