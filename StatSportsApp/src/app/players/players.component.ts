import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PlayerService } from '../services/player.service';
import { Players } from '../models/players';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.scss'],
})
export class PlayersComponent implements OnInit {
  players$: Observable<Players[]>;

  constructor(private PlayersService: PlayerService) {
  }

  ngOnInit() {
    this.loadPlayers();
  }

  loadPlayers() {
    this.players$ = this.PlayersService.getPlayers();
  }

  delete(id) {
    const ans = confirm('Do you want to delete blog post with id: ' + id);
    if (ans) {
      this.PlayersService.deletePlayers(id).subscribe((data) => {
        this.loadPlayers();
      });
    }
  }
}