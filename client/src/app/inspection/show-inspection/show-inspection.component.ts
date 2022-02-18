import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from 'src/app/app.service';

@Component({
  selector: 'app-show-inspection',
  templateUrl: './show-inspection.component.html',
  styleUrls: ['./show-inspection.component.css']
})
export class ShowInspectionComponent implements OnInit {
  inspectionList$!: Observable<any[]>;
  inspectionTypesList$!: Observable<any[]>;
  inspectionTypesList: any = [];
  modalTitle: string = '';
  activateAddEditInspectionComponent = false;
  inspection: any;

  //Map to display data assocaite with foreign Key
  inspectionTypesMap: Map<number, string> = new Map();

  constructor(private apService: ApiService) { }

  ngOnInit(): void {
    this.inspectionList$ = this.apService.getInspectionList();
    this.inspectionTypesList$ = this.apService.getInspectionTypeList();
    this.refreshInspectionTypesMap();
  }

  modalAdd() {
    this.inspection = {
      id: 0,
      status: null,
      comments: null,
      inspectionTypeId: null
    }
    this.modalTitle = 'Add Inspection';
    this.activateAddEditInspectionComponent = true;
  }

  modalUpdate(item: any) {
    this.inspection = item;
    this.modalTitle = "Update Inspection",
    this.activateAddEditInspectionComponent = true;
  }

  deleteBtn(item: any) {
    if (confirm('Are you sure you want to delete ' + item.inspectionName)) {
      this.apService.deleteInspection(item.id).subscribe(response => {
        var showDeleteSuccess = document.getElementById('delete-success-alert');
        if (showDeleteSuccess) {
          showDeleteSuccess.style.display = "block";
        }
        setTimeout(function() {
          if (showDeleteSuccess) {
            showDeleteSuccess.style.display = "none"
          }
        }, 4000);

        this.inspectionList$ = this.apService.getInspectionList();
      })
    }
  }

  modalClose() {
    this.activateAddEditInspectionComponent = false;
    this.inspectionList$ = this.apService.getInspectionList();
  }

  refreshInspectionTypesMap() {
    this.apService.getInspectionTypeList().subscribe(data => {
      this.inspectionTypesList = data;

      for (let i = 0; i < data.length; i++) {
        this.inspectionTypesMap.set(this.inspectionTypesList[i].id, this.inspectionTypesList[i].inspectionName);
        
      }
    })
  }

}
