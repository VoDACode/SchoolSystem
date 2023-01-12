import { Component, OnInit } from '@angular/core';
import { GroupApiService } from 'src/app/services/api/group.api/group.api.service';
import { StatsService } from 'src/app/services/api/stats/stats.service';
import { Group } from 'src/models/Group';

@Component({
  selector: 'app-admin-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class AdminHomeComponent implements OnInit {

  studentsPerTeacher: number = 0;
  parentInGroup: number = 0;
  parentInStream: number = 0;
  studentsInStream: number = 0;
  studentsInGroup: number = 0;
  classes: Group[] = [];

  constructor(private stats: StatsService,
            private group: GroupApiService) { }

  ngOnInit(): void {
    this.stats.getTeachers().then(res => {
      this.studentsPerTeacher = res.data?.teachersPerStudent || 0;
    });
    this.group.getGroups().then(res => {
      this.classes = res.data?.data || [];
    });
  }

  changeGroup(event: any) { 
    this.stats.getParentsInGroup(event.target.value).then(res => {
      this.parentInGroup = res.data?.length || 0;
    });
    let streamNum = event.target.value.split('-')[0];
    this.stats.getParents(streamNum).then(res => {
      this.parentInStream = res.data?.reduce((a, b) => a + b.parents, 0) || 0;
    });
    this.stats.getStudents(streamNum).then(res => {
      this.studentsInStream = res.data?.reduce((a, b) => a + b.students, 0) || 0;
    });
    this.studentsInGroup = this.classes.find(c => c.groupCode === event.target.value)?.studentsIds?.length || 0;
  }

}
