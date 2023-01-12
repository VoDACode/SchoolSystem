import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ReportsService {

  constructor() { }

  downloadStudentsList(group: string): void {
    fetch(`/api/reports/students-list?g=${group}`, {
      method: 'GET',
    }).then(response => response.blob())
      .then(blob => {
        var url = window.URL.createObjectURL(blob);
        var a = document.createElement('a');
        a.href = url;
        a.download = 'students-list.docx';
        document.body.appendChild(a);
        a.click();
        a.remove();
      });
  }

  downloadCertificateOfStudent(studentId: number, whom: string): void {
    fetch(`/api/reports/certificate-of-student?id=${studentId}&whom=${whom}`, {
      method: 'GET',
    }).then(response => response.blob())
    .then(blob => {
      var url = window.URL.createObjectURL(blob);
      var a = document.createElement('a');
      a.href = url;
      a.download = 'certificate-of-student.docx';
      document.body.appendChild(a);
      a.click();
      a.remove();
    });;
  }
}
