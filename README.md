# VRChat_LipSyncSelect
VRChat用のLipSyncを、一括設定する拡張ツールです。
※Viseme Blend Shapeのみ対応

## 使用方法
1. リップシンク設定

    VRC_Avatar Descriptorで右クリックで、表示されるメニューを選択することで、LipSyncのVisemeが選択されます。

1. エクスポート

    エクスポートを行うと下記のフォルダに「●●Tmp.cs」が作成されて、右クリックメニューに追加されます。

    出力されたファイルを他の環境の同一フォルダに、コピーすることでメニューに追加することができます。

    「Assets\ExpansionTools\LipSyncSelect\tmp」



## 自動選択対応リスト
* Lip Sync Auto Select(.*[^A-Za-z]sil$)　（名称の後方一致）
* AiueoSilPP（固定一致　Sil, PP, i, e, a, o, u）
* LC01LipSync（固定一致　LC01.sil, LC01.ih, LC01.ch, LC01.ss, LC01.aa, LC01.oh, LC01.ou）
* Standard001（固定一致　vrc.v_sil, vrc.v_pp, vrc.v_ff, vrc.v_th, vrc.v_dd, vrc.v_kk, vrc.v_ch, vrc.v_ss, vrc.v_nn, vrc.v_rr, vrc.v_aa, vrc.v_ee, vrc.v_ih, vrc.v_oh, vrc.v_ou）
* Standard002JP（固定一致 あいうえお）



## バージョンについて
v3.0.0

v{メジャーバージョン}.{マイナーバージョン}.{バグフィックス}

1. メジャーバージョン：レイアウト変更を伴う機能追加、または、使用するライブラリ群の変更、更新
1. マイナーバージョン：メジャーバージョンの変更外の機能追加
1. バグフィックス　　：バグの修正単位（コード改善含む）


## 変更履歴
* v2.0.0

    コピー、ペースト機能の追加

* v3.0.0

    エクスポート機能の追加

    デフォルトの対応リストを追加
